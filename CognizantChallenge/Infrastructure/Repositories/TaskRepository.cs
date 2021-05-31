using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognizantChallenge.Domain;
using CognizantChallenge.Domain.Context;
using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CognizantChallenge.Infrastructure.Repositories {
    public class TaskRepository : ITaskRepository {
        private readonly ITaskContext context;

        public TaskRepository(ITaskContext taskContext) {
            context = taskContext ?? throw new ArgumentNullException(nameof(taskContext));
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<TaskEntity>> List() {
            return await context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity> Get(Guid id) {
            return await context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<TaskEntity>> GetByName(string name) {
            return await context.Tasks.Where(p => p.TaskName == name).ToListAsync();
        }

        public async Task Create(TaskEntity task) {
            await context.Tasks.AddAsync(task);
        }

        public void Update(TaskEntity task) {
            context.Tasks.Update(task);
        }

        public void Delete(TaskEntity task) {
            context.Tasks.Remove(task);
        }

        public async Task Delete(Guid id) {
            var task = await context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
            context.Tasks.Remove(task);
        }
    }
}