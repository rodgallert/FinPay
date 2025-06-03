using Application.Controllers.ActionFilters;
using Application.Validators;
using Domain.DTO;
using FluentValidation;
using Infrastructure;
using UseCases;

namespace Application.IoC;

public static class Bootstrapper
{
    public static IServiceCollection InjectServices(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddTransient<IApiKeyValidator, ApiKeyValidator>();
        services.AddTransient<ApiKeyAttribute>();
        services.AddTransient<ApiKeyAuthorizationFilter>();

        services.AddHttpClient();
        services.AddHttpContextAccessor();

        services.InjectValidators();
        services.InjectUseCases(environment);
        services.InjectInfrastructure(environment);


        return services;
    }

    private static IServiceCollection InjectValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<UserDto>, UserValidator>();

        return services;
    }
}
