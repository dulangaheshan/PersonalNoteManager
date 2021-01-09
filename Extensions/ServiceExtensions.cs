/**
 * @author [D.5haN]
 * @email [dulngah@gmail.com]
 * @create date 2021-01-08 18:47:55
 * @modify date 2021-01-08 18:47:55
 * @desc [Extension Methods and CORS Configuration]
 */
using CordFortPersonalNoteManager.Contracts;
using CordFortPersonalNoteManager.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Extensions
{
    public static class ServiceExtensions
    {
        /**
         * Cors Enable
         * **/
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        /**
         * IIS Configuration
         */

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        // configure Sql connection 

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {

            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>
                (o =>
                {
                    o.UseMySql(connectionString);
                });
        }

        // Repository Configurations
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
