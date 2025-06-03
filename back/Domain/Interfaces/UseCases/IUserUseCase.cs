using Domain.DTO;

namespace Domain.Interfaces.UseCases;
public interface IUserUseCase
{
    Task<UserDto> CreateUserAsync(UserDto userRequest);
}
