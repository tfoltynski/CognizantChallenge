using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CognizantChallenge.Application.Exceptions;
using CognizantChallenge.Application.Tasks.DTO;
using CognizantChallenge.DistributedService;
using CognizantChallenge.DistributedService.JDoodle.DTO;
using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Domain.Repositories;
using CognizantChallenge.Domain.Services;
using JetBrains.Annotations;

namespace CognizantChallenge.Application.Tasks.Services {
    public class TaskService : ITaskService {
        [NotNull]
        private readonly IUserRepository userRepository;

        [NotNull]
        private readonly ITaskRepository taskRepository;

        [NotNull]
        private readonly IMapper mapper;

        [NotNull]
        private readonly ITaskDomainService taskDomainService;

        [NotNull]
        private readonly ICompilerService<JDoodleCompileOutput, JDoodleCompileInput> compilerService;

        public TaskService([NotNull] IUserRepository userRepository, [NotNull] ITaskRepository taskRepository, [NotNull] IMapper mapper,
            [NotNull] ITaskDomainService taskDomainService,
            [NotNull] ICompilerService<JDoodleCompileOutput, JDoodleCompileInput> compilerService) {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.taskDomainService = taskDomainService ?? throw new ArgumentNullException(nameof(taskDomainService));
            this.compilerService = compilerService ?? throw new ArgumentNullException(nameof(compilerService));
        }

        public async Task<GetTaskOutput> GetTask(GetTaskInput input) {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var task = await taskRepository.Get(input.TaskId);
            return mapper.Map<TaskEntity, GetTaskOutput>(task);
        }

        public async Task<ListTaskOutput> ListTasks() {
            var task = await taskRepository.List();
            return mapper.Map<IEnumerable<TaskEntity>, ListTaskOutput>(task);
        }

        public async Task<SubmitTaskOutput> SubmitTask(SubmitTaskInput input) {
            var task = await taskRepository.Get(input.TaskId);
            if (task is null) throw new MissingEntityException(nameof(TaskEntity), input.TaskId.ToString());

            var compilerInputDto = new JDoodleCompileInput {
                Input = task.Input,
                Code = input.Code,
                Language = "csharp",
                LanguageVersionIndex = "0"
            };
            var compileResult = await compilerService.Compile(compilerInputDto);
            if (compileResult == null) return new SubmitTaskOutput {IsCorrect = false, Output = "Compiler failed to complete operation."};

            if ((HttpStatusCode) compileResult.StatusCode == HttpStatusCode.OK) {
                var wasAdded = await taskDomainService.TryAddToSolvedTasks(task, input.UserName, compileResult.Output);
                if (!wasAdded) return new SubmitTaskOutput {IsCorrect = false, Output = compileResult.Output, Expected = task.Output};
            } else
                return new SubmitTaskOutput {IsCorrect = false, Output = compileResult.Output};

            return new SubmitTaskOutput {IsCorrect = true};
        }
    }
}