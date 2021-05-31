using System;
using System.Collections.Generic;

namespace CognizantChallenge.Domain.Entities {
    public class TaskEntity {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}