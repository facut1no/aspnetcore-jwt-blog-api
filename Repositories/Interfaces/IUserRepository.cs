using PostCommentAPI.Models;
using PostCommentAPI.Repositories;

public interface IUserRepository : IRepository<User>
{
  Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

  Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);

  Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

  Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);
}