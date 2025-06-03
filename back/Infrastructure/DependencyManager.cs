using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyManager
{
    public static IServiceCollection InjectInfrastructure(this IServiceCollection services, 
        IWebHostEnvironment environment)
    {
        var environmentName = environment.EnvironmentName;

        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.Infrastructure.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.Infrastructure.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddDbContext<FinPayContext>(opt => 
            opt.UseNpgsql(builder.GetConnectionString("DefaultConnection")));

        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}
