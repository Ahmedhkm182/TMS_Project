using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Teams).WithMany(t => t.Users);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Tasks)
                .WithOne(task => task.Team)
                .HasForeignKey(task => task.TeamId);

            modelBuilder.Entity<ProjectTask>()
                .HasMany(t => t.SubTasks)
                .WithOne(st => st.Task)
                .HasForeignKey(st => st.TaskId);
        }
    }
}
