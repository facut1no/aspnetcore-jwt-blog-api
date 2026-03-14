using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public interface ICommentRepository : IRepository<Comment>
{
  Task<bool> ExistsAsync(Guid commentId, CancellationToken cancellationToken);
  Task<int> CountByPostId(Guid postId, CancellationToken cancellationToken);
  Task<IEnumerable<Comment>> GetByPostId(Guid postId, CancellationToken cancellationToken);
  Task<IEnumerable<Comment>> GetByUserId(Guid userId, CancellationToken cancellationToken);
  Task<IEnumerable<Comment>> GetRepliesByCommentId(Guid parentCommentId, CancellationToken cancellationToken);
  Task<IEnumerable<Comment>> GetRootCommentsByPostId(Guid postId, CancellationToken cancellationToken);
}