using System;
using System.Collections.Generic;

namespace CognizantChallenge.Application.Tasks.DTO {
    public sealed class ListTaskOutput {
        public IEnumerable<ListTaskDto> Tasks { get; set; }

        public sealed class ListTaskDto {
            public Guid Id { get; set; }

            public string TaskName { get; set; }

            public string Description { get; set; }
        }
    }
}