using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FinPayContext context) : base(context)
    {
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context
            .Users
            .AnyAsync(x => x.Email.ToLower() == email.ToLower()
                && x.IsActive);
    }
}
