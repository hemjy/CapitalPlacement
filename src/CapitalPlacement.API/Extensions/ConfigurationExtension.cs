using CapitalPlacement.Application;
using CapitalPlacement.Application.Services;
using CapitalPlacement.Domain.Infrastructure.Respository;
using CapitalPlacement.Domain.Services;
using CapitalPlacement.Infrastructure.Repositories;
using System.Reflection;

namespace CapitalPlacement.API.Extensions
{
    public static class ConfigurationExtension
    {
        public static void AddProgramServices(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            services.AddApplicationServices();
        }
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
           services.AddScoped<ICPProgramRepository, CPProgramRepository>();
        }
    }
}
