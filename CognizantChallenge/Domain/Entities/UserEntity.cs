using System;
using System.Collections.Generic;

namespace CognizantChallenge.Domain.Entities {
    public class UserEntity {
        public Guid Id { get; set; }

        public string User { get; set; }

        public ICollection<TaskEntity> SolvedTasks { get; set; }
    }
}