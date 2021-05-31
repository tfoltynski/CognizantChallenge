using System.Threading.Tasks;
using CognizantChallenge.Application.User.DTO;
using JetBrains.Annotations;

namespace CognizantChallenge.Application.User.Services {
    public interface IUserService {
        [Pure]
        Task<ListUserOutput> ListUsers();
    }
}