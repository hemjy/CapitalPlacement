using CapitalPlacement.Application.Services;
using CapitalPlacement.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CapitalPlacement.Application
{
    public static class ConfigurationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProgramProcessingService, ProgramProcessingService>();
            services.AddScoped<IApplicationFormService, ApplicationFormService>();
            services.AddScoped<IWorkflowService, WorkflowService>();
        }
    }
}
