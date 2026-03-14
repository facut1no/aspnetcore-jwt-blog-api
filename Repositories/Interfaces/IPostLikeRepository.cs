using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public interface IPostLikeRepository : IRepository<PostLike>
{
  Task<bool> ExistsAsync(Guid userId, Guid postId, CancellationToken cancellationToken);

  Task<int> CountByPostIdAsync(Guid postId, CancellationToken cancellationToken);

  Task<IEnumerable<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken);

  Task<PostLike?> GetByUserAndPostAsync(Guid userId, Guid postId, CancellationToken cancellationToken);
}