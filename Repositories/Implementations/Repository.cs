using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : BaseModel
{
  private readonly ApplicationDbContext _context = context;
  protected readonly DbSet<T> _dbSet = context.Set<T>();
  public async Task AddAsync(T entity, CancellationToken cancellationToken)
  {
    await _dbSet.AddAsync(entity, cancellationToken);
  }

  public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
  {
    return await _dbSet.FindAsync([id], cancellationToken);
  }

  public void SoftDelete(T entity)
  {
    entity.IsDeleted = true;
    entity.DeletedTimeUtc = DateTime.UtcNow;
  }

  public void HardDelete(T entity)
  {
    _dbSet.Remove(entity);
  }

  public async Task SaveChangeAsync(CancellationToken cancellationToken)
  {
    await _context.SaveChangesAsync(cancellationToken);
  }


}