using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CognizantChallenge.Domain.Entities;

namespace CognizantChallenge.Domain.Repositories {
    public interface ITaskRepository {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<TaskEntity>> List();

        Task<TaskEntity> Get(Guid id);

        Task<IEnumerable<TaskEntity>> GetByName(string name);

        Task Create(TaskEntity task);

        void Update(TaskEntity task);

        void Delete(TaskEntity task);

        Task Delete(Guid id);
    }
}