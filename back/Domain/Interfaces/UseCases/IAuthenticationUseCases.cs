using Domain.Options;

namespace Domain.Interfaces.UseCases;
public interface IAuthenticationUseCases
{
    string GenerateToken(string email, Guid publicId);
    public Guid GetUserIdFromToken();
}
