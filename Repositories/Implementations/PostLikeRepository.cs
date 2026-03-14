using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public sealed class PostLikeRepository(ApplicationDbContext context) : Repository<PostLike>(context), IPostLikeRepository
{
  public async Task<int> CountByPostIdAsync(Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .CountAsync(cl => cl.PostId == postId && cl.PostId == postId, cancellationToken);
  }

  public async Task<bool> ExistsAsync(Guid userId, Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .AnyAsync(cl => cl.UserId == userId, cancellationToken);
  }

  public async Task<IEnumerable<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(cl => cl.PostId == postId).ToListAsync(cancellationToken);
  }

  public async Task<PostLike?> GetByUserAndPostAsync(Guid userId, Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .FirstOrDefaultAsync(cl => cl.UserId == userId && cl.PostId == postId, cancellationToken);
  }
}