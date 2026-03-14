using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public sealed class CommentRepositoy(ApplicationDbContext context) : Repository<Comment>(context), ICommentRepository
{
  public async Task<int> CountByPostId(Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .CountAsync(c => c.PostId == postId, cancellationToken);
  }

  public async Task<bool> ExistsAsync(Guid commentId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AnyAsync(c => c.Id == commentId, cancellationToken);
  }

  public async Task<IEnumerable<Comment>> GetByPostId(Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(c => c.PostId == postId).ToListAsync(cancellationToken);
  }

  public async Task<IEnumerable<Comment>> GetByUserId(Guid userId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(c => c.UserId == userId).ToListAsync(cancellationToken);
  }

  public async Task<IEnumerable<Comment>> GetRepliesByCommentId(Guid parentCommentId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(c => c.ParentCommentId == parentCommentId).ToListAsync(cancellationToken);
  }

  public async Task<IEnumerable<Comment>> GetRootCommentsByPostId(Guid postId, CancellationToken cancellationToken)
  {
    return await _dbSet
      .AsNoTracking()
      .Where(c => c.PostId == postId && c.ParentComment == null)
      .ToListAsync(cancellationToken);
  }
}