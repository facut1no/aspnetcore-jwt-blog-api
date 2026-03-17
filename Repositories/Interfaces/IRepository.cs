using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public interface IRepository<T> where T : BaseModel
{
  Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
  Task<T?> AddAsync(T entity, CancellationToken cancellationToken);
  void SoftDelete(T entity);
  void HardDelete(T entity);
  Task SaveChangeAsync(CancellationToken cancellationToken);
}
