using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public sealed class PostRepository(ApplicationDbContext context) : Repository<Post>(context), IPostRepository
{

  public async Task<bool> ExistsAsync(Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .AnyAsync(p => p.Id == postId, cancellationToken);
  }

  public async Task<IEnumerable<Post>> GetAllAsync(CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .ToListAsync(cancellationToken);
  }

  public async Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(p => p.UserId == userId)
      .ToListAsync(cancellationToken);
  }

  public void Update(Post post)
  {
    throw new NotImplementedException();
  }
}