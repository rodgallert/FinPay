using Domain.DTO;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace UseCases;
public class UserUseCase : IUserUseCase
{
    private readonly IUserRepository userRepository;
    private readonly IAuthenticationUseCases _authenticationUseCases;

    public UserUseCase(IUserRepository userRepository, IAuthenticationUseCases authenticationUseCases)
    {
        this.userRepository = userRepository;
        _authenticationUseCases = authenticationUseCases;
    }

    public async Task<UserDto> CreateUserAsync(UserDto userRequest)
    {
        if (await userRepository.UserExistsAsync(userRequest.Email))
            throw new UnprocessableRequestException("User already registered.");

        var user = User.FromCreate(userRequest);

        user = await userRepository.AddAsync(user);

        var token = _authenticationUseCases.GenerateToken(user.Email, user.PublicId);

        return User.ToDto(user);
    }
}
