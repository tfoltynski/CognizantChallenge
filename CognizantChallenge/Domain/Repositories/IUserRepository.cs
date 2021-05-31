using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Infrastructure;

namespace CognizantChallenge.Domain.Repositories {
    public interface IUserRepository {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<UserEntity>> List();
        
        Task<UserEntity> GetByUserName(string name);

        Task Create(UserEntity userTask);

        void Update(UserEntity userTask);

        Task Delete(Guid id);

        void Delete(UserEntity userTask);
    }
}