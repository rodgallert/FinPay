using Domain.Entities;

namespace Domain.Interfaces.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<bool> UserExistsAsync(string email);
}
