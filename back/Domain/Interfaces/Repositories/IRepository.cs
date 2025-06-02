using Domain.Entities;

namespace Domain.Interfaces.Repositories;
public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(long id);
    Task<T> GetByPublicIdAsync(Guid publicId);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
