using Application.Controllers.ActionFilters;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
//[ApiKey]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    protected readonly IAuthenticationUseCases _authenticationUseCases;

    protected BaseController(IAuthenticationUseCases authenticationUseCases)
        => _authenticationUseCases = authenticationUseCases;

    protected Guid LoggedUserPublicId()
        => _authenticationUseCases.GetUserIdFromToken();
}
