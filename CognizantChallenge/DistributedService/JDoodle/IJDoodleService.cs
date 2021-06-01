using System.Threading.Tasks;
using CognizantChallenge.DistributedService.JDoodle.DTO;

namespace CognizantChallenge.DistributedService.JDoodle {
    public interface IJDoodleService {
        Task<JDoodleCompileOutput> Compile(JDoodleCompileInput input);
    }
}