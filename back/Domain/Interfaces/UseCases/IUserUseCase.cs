using Domain.DTO;
using Domain.ViewModels;

namespace Domain.Interfaces.UseCases;
public interface IUserUseCase
{
    Task<LoginViewModel> CreateUserAsync(UserDto userRequest);
}
