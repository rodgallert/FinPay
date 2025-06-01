using Application.Controllers.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[ApiKey]
[Route("[controller]")]
public class BaseController : ControllerBase
{
}
