using Application.Validators;
using Domain.DTO;
using Domain.Interfaces.UseCases;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;
public class UserController : BaseController
{
    private readonly IValidator<UserDto> _userValidator;
    public UserController(IAuthenticationUseCases authenticationUseCases, IValidator<UserDto> userValidator) : base(authenticationUseCases) 
        => this._userValidator = userValidator;

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userRequest, 
        [FromServices] IUserUseCase userUseCase)
    {
        var validationResult = await _userValidator.ValidateAsync(userRequest, options => options.IncludeRuleSets("Create"));

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        return Ok(await userUseCase.CreateUserAsync(userRequest));
    }
}
