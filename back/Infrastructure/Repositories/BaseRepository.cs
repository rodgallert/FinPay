using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly FinPayContext _context;

    public BaseRepository(FinPayContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(T entity)
    {
        entity.IsActive = false;
        
        await UpdateAsync(entity);
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id 
                && x.IsActive);
    }

    public async Task<T> GetByPublicIdAsync(Guid publicId)
    {
        return await _context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.PublicId == publicId
                && x.IsActive);
    }

    public async Task<T> AddAsync(T entity)
    {
        var obj = await _context
            .Set<T>()
            .AddAsync(entity);

        await _context.SaveChangesAsync();

        return obj.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {

        entity.UpdatedAt = DateTime.UtcNow;
        var obj = _context.Set<T>()
            .Update(entity);
        await _context.SaveChangesAsync();

        return obj.Entity;
    }
}
