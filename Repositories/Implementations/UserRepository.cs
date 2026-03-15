namespace PostCommentAPI.Repositories;

using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;


public sealed class UserRepositoty(ApplicationDbContext context) : Repository<User>(context), IUserRepository
{

  public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
  {
    return await _dbSet.AsNoTracking().AnyAsync(u => u.Email == email, cancellationToken);
  }

  public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
  {
    return await _dbSet.AsNoTracking().AnyAsync(u => u.Username == username, cancellationToken);
  }

  public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
  {
    return await _dbSet.AsNoTracking().FirstOrDefaultAsync(
      u => string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0,
      cancellationToken
    );
  }

  public async Task<bool> ExistsUser(string username, string email, CancellationToken cancellationToken)
  {
    return await _dbSet.AnyAsync(u => u.Email == email && u.Username == username, cancellationToken);
  }


  public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
  {
    return await _dbSet.AsNoTracking().FirstOrDefaultAsync(
      u => string.Compare(u.Username, username, StringComparison.OrdinalIgnoreCase) == 0,
      cancellationToken
    );
  }

}