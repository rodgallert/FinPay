using Domain.Interfaces.UseCases;
using Domain.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UseCases;
public static class DependencyManager
{
    public static IServiceCollection InjectUseCases(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        var environmentName = environment.EnvironmentName;

        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.UseCases.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.UseCases.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddTransient<IAuthenticationUseCases, AuthenticationUseCases>();
        services.AddTransient<IUserUseCase, UserUseCase>();

        services.Configure<JwtOptions>(builder.GetSection("JwtOptions"));

        return services;
    }
}
