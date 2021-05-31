using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CognizantChallenge.Domain;
using CognizantChallenge.Domain.Context;
using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CognizantChallenge.Infrastructure.Repositories {
    public class UserRepository : IUserRepository {
        private readonly ITaskContext context;

        public UserRepository(ITaskContext context) {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<UserEntity>> List() {
            return await context.Users.Include(p => p.SolvedTasks).ToListAsync();
        }

        public async Task<UserEntity> GetByUserName(string name) {
            return await context.Users.Include(p => p.SolvedTasks).FirstOrDefaultAsync(p => p.User == name);
        }

        public async Task Create(UserEntity userTask) {
            await context.Users.AddAsync(userTask);
        }

        public void Update(UserEntity userTask) {
            context.Users.Update(userTask);
        }

        public async Task Delete(Guid id) {
            var userTask = await context.Users.FirstOrDefaultAsync(p => p.Id == id);
            context.Users.Remove(userTask);
        }

        public void Delete(UserEntity userTask) {
            context.Users.Remove(userTask);
        }
    }
}