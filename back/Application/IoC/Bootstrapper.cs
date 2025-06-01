using Application.Controllers.ActionFilters;

namespace Application.IoC;

public static class Bootstrapper
{
    public static IServiceCollection InjectServices(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddTransient<IApiKeyValidator, ApiKeyValidator>();
        services.AddTransient<ApiKeyAttribute>();
        services.AddTransient<ApiKeyAuthorizationFilter>();

        return services;
    }
}
