using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CognizantChallenge.DistributedService {
    public interface IRequestService {
        [ItemCanBeNull]
        Task<T> Post<T>([NotNull] string url, [NotNull] object input);
    }
}