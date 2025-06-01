using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Controllers.ActionFilters;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private readonly string _apiKeyHeaderName = "X-Api-Key";
    private readonly IApiKeyValidator _apiKeyValidator;

    public ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator)
        => _apiKeyValidator = apiKeyValidator;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string apiKey = context.HttpContext.Request.Headers[_apiKeyHeaderName];
        
        if (string.IsNullOrEmpty(apiKey)
            || !_apiKeyValidator.IsValid(apiKey))
            context.Result = new UnauthorizedResult();
    }
}

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IConfiguration _configuration;

    public ApiKeyValidator(IConfiguration configuration)
        => _configuration = configuration;

    public bool IsValid(string apiKey)
        => _configuration["X-Api-Key"] == apiKey;
}
