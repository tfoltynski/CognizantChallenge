using System;

namespace CognizantChallenge.Application.Tasks.DTO {
    public sealed class SubmitTaskInput {
        public string UserName { get; set; }

        public Guid TaskId { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }
    }
}