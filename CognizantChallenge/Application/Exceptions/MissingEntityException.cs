using System;
using JetBrains.Annotations;

namespace CognizantChallenge.Application.Exceptions {
    public class MissingEntityException : Exception {
        public readonly string EntityName;

        public readonly string EntityKey;

        public MissingEntityException([NotNull] string entityName, [NotNull] string entityKey) : base($"Missing entity '{entityName}' with Id '{entityKey}'.") {
            this.EntityName = entityName ?? throw new ArgumentNullException(nameof(entityName));
            this.EntityKey = entityKey ?? throw new ArgumentNullException(nameof(entityKey));
        }
    }
}