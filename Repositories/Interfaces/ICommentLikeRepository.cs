using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public interface ICommentLikeRepository : IRepository<CommentLike>
{
  Task<bool> ExistsAsync(Guid userId, Guid commentId, CancellationToken cancellationToken);

  Task<int> CountByCommentIdAsync(Guid commentId, CancellationToken cancellationToken);

  Task<IEnumerable<CommentLike>> GetByCommentIdAsync(Guid commentId, CancellationToken cancellationToken);

  Task<CommentLike?> GetByUserAndCommentAsync(Guid userId, Guid commentId, CancellationToken cancellationToken);
}