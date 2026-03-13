using PostCommentAPI.Models;

public interface IUserRepository
{
  Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

  Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);

  Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

  Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);

  Task AddAsync(User user, CancellationToken cancellationToken);

  Task SaveChangesAsync(CancellationToken cancellationToken);
}