using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;
public class TestController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Test endpoint is working!");
    }
}
