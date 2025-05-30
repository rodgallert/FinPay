using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure;

public static class DependencyManager
{
    public static IServiceCollection InjectInfrastructure(this IServiceCollection services, IWebHostEnvironment environment)
    {
        return services;
    }
}
