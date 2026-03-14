namespace PostCommentAPI.Repositories;

using PostCommentAPI.Models;

public interface IPostRepository : IRepository<Post>
{
  Task<IEnumerable<Post>> GetAllAsync(CancellationToken cancellationToken);
  Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
  Task<bool> ExistsAsync(Guid postId, CancellationToken cancellationToken);
  void Update(Post post);
}