using AutoMapper;

using HrTasks.Services.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using HrTasks.Model;
using Microsoft.EntityFrameworkCore;

using HrTasks.Services.Services;
using System.Linq;
using System.Reflection;
using NetCore.AutoRegisterDi;
using HrTasks.ModelAccess;
using Common;

namespace HrTasks.Services.Extensions
{
 public static   class ConfigureServicesExtension
    {
        public static IServiceCollection ServicesRegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.DatabaseConfig(configuration);
            Mapper.Initialize(config => config.AddProfile<HrTasksMapper>());
            services.AddAutoMapper();
            services.ServicesConfig();
            return services;
        }
        private static void DatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HR");
            services.AddDbContext<HrTasksContext>
                (options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
            services.AddScoped<DbContext, HrTasksContext>();

            var auditConnectionString = configuration.GetConnectionString("Audit");

            services.AddDbContext<AuditLogsContext>
               (options => options.UseSqlServer(auditConnectionString).EnableSensitiveDataLogging());
        }
        private static void ServicesConfig(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork>();
            var assemblyToScan = Assembly.GetAssembly(typeof(EmployeeService));
            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
              .Where(c => c.Name.EndsWith("Service"))
              .AsPublicImplementedInterfaces();
        }
    }
}
