using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public sealed class CommentLikeRepository(ApplicationDbContext context) : Repository<CommentLike>(context), ICommentLikeRepository
{
  public async Task<int> CountByCommentIdAsync(Guid commentId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .CountAsync(cl => cl.CommentId == commentId, cancellationToken);
  }

  public async Task<bool> ExistsAsync(Guid userId, Guid commentId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .AnyAsync(cl => cl.UserId == userId && cl.CommentId == commentId, cancellationToken);
  }

  public async Task<IEnumerable<CommentLike>> GetByCommentIdAsync(Guid commentId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(cl => cl.CommentId == commentId)
      .ToListAsync(cancellationToken);
  }

  public async Task<CommentLike?> GetByUserAndCommentAsync(Guid userId, Guid commentId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .FirstOrDefaultAsync(cl => cl.CommentId == commentId && cl.UserId == userId, cancellationToken);
  }
}