using System;
using System.Threading.Tasks;

namespace CognizantChallenge.Domain {
    public interface IUnitOfWork : IDisposable {
        Task Commit();
    }
}