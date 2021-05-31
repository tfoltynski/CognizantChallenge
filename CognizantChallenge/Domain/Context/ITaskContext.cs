using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CognizantChallenge.Domain.Context {
    public interface ITaskContext : IUnitOfWork {
        DbSet<TaskEntity> Tasks { get; set; }

        DbSet<UserEntity> Users { get; set; }
    }
}