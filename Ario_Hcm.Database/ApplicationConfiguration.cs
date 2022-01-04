using System;
using Ario_Hcm.Core.Database;
using Ario_Hcm.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ario_Hcm.Database
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(configure =>
           {
               configure.UseSqlite("Filename=main.db");
               configure.EnableDetailedErrors(true);
               configure.ConfigureWarnings(opt =>
               {
                   opt.Default(WarningBehavior.Log);
               });

           });
            services.AddScoped<IDatabaseContext, DatabaseContext>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            return services;
        }

        public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<DatabaseContext>();

            context.Database.Migrate();

            return app;
        }
    }
}
