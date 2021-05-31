using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CognizantChallenge.DistributedService {
    public interface ICompilerService<TO, in T> {
        [ItemCanBeNull]
        Task<TO> Compile([NotNull] T input);
    }
}