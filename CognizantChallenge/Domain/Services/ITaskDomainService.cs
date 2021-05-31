using System.Threading.Tasks;
using CognizantChallenge.Domain.Entities;
using JetBrains.Annotations;

namespace CognizantChallenge.Domain.Services {
    public interface ITaskDomainService {
        Task<bool> TryAddToSolvedTasks([NotNull] TaskEntity task, [NotNull] string userName, string compileOutput);
    }
}