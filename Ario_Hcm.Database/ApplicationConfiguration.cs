using System;
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
