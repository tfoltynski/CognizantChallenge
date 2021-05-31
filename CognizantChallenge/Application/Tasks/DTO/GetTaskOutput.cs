using System;

namespace CognizantChallenge.Application.Tasks.DTO {
    public sealed class GetTaskOutput {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }
    }
}