using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Ario_Hcm.Core.Database;
using Ario_Hcm.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Ario_Hcm.Database
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<User> Users { get; set; }

        public Task CommitAsync()
        {
            return SaveChangesAsync();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Soutce=main.db", opt =>
                {
                    opt.MigrationsAssembly("Hcm.Api");
                    opt.MigrationsHistoryTable("migration", "dbo");
                });
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
