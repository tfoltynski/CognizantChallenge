using System.Threading.Tasks;
using CognizantChallenge.Domain.Context;
using CognizantChallenge.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace CognizantChallenge.Infrastructure.Context {
    public class TaskContext : DbContext, ITaskContext {
        public TaskContext([NotNull] DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public async Task Commit() {
            await this.SaveChangesAsync();
        }

        public override async void Dispose() {
            await this.DisposeAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TaskEntity>().HasData(TaskContextSeed.GetTasks());
            modelBuilder.Entity<TaskEntity>().HasMany(p => p.Users).WithMany(p => p.SolvedTasks).UsingEntity(c => c.ToTable("UserTasks"));
        }
    }
}