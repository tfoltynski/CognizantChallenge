using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Domain.Repositories;

namespace CognizantChallenge.Domain.Services {
    public class TaskDomainService : ITaskDomainService {
        private readonly IUserRepository userRepository;

        public TaskDomainService(IUserRepository userRepository) {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> TryAddToSolvedTasks(TaskEntity task, string userName, string compileOutput) {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(userName));

            var user = await userRepository.GetByUserName(userName);

            if (!string.IsNullOrWhiteSpace(compileOutput) && IsCorrectSolution(compileOutput, task.Output)) {
                if (user is null) {
                    await userRepository.Create(new UserEntity {
                        User = userName,
                        SolvedTasks = new List<TaskEntity> {task}
                    });
                } else {
                    user.SolvedTasks.Add(task);
                    userRepository.Update(user);
                }

                await userRepository.UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        private bool IsCorrectSolution(string compileOutput, string expectedOutput) {
            var compileOutputChars = compileOutput.ToCharArray();
            var expectedOutputChars = expectedOutput.ToCharArray();
            if (compileOutputChars.Length < expectedOutputChars.Length) return false;

            for (var i = 0; i < expectedOutputChars.Length; i++) {
                if (expectedOutputChars[i] != compileOutputChars[i]) return false;
            }

            return true;
        }
    }
}