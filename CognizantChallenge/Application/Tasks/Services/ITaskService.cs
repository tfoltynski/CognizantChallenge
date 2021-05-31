using System.Threading.Tasks;
using CognizantChallenge.Application.Tasks.DTO;
using JetBrains.Annotations;

namespace CognizantChallenge.Application.Tasks.Services {
    public interface ITaskService {
        [Pure] [ItemNotNull]
        Task<GetTaskOutput> GetTask([NotNull] GetTaskInput input);

        [ItemNotNull]
        Task<SubmitTaskOutput> SubmitTask([NotNull] SubmitTaskInput input);

        Task<ListTaskOutput> ListTasks();
    }
}