using System;
using System.Threading.Tasks;
using CognizantChallenge.Application.Tasks.DTO;
using CognizantChallenge.Application.Tasks.Services;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CognizantChallenge.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase {
        [NotNull]
        private readonly ILogger<TaskController> logger;

        [NotNull]
        private readonly ITaskService taskService;

        public TaskController([NotNull] ILogger<TaskController> logger, [NotNull] ITaskService taskService) {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet("[action]/{taskId}")]
        public async Task<ActionResult<GetTaskOutput>> GetTask(Guid taskId) {
            var task = await this.taskService.GetTask(new GetTaskInput {TaskId = taskId});
            return Ok(task);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ListTaskOutput>> ListTasks() {
            var tasks = await this.taskService.ListTasks();
            return Ok(tasks);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SubmitTaskOutput>> Submit([FromBody] SubmitTaskInput input) {
            var result = await this.taskService.SubmitTask(input);
            return Ok(result);
        }
    }
}