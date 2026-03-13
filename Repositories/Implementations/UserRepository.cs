using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Data;
using PostCommentAPI.Models;

namespace PostCommentAPI.Repositories;

public sealed class UserRepositoty(ApplicationDbContext context) : IUserRepository
{
  private readonly ApplicationDbContext _context = context;
  public async Task AddAsync(User user, CancellationToken cancellationToken)
  {
    await _context.Users.AddAsync(user, cancellationToken);
  }

  public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
  {
    return await _context.Users.AsNoTracking().AnyAsync(u => u.Email == email, cancellationToken);
  }

  public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
  {
    return await _context.Users.AsNoTracking().AnyAsync(u => u.Username == username, cancellationToken);
  }

  public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
  {
    return await _context.Users.AsNoTracking().FirstOrDefaultAsync(
      u => string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0,
      cancellationToken
    );
  }

  public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
  {
    return await _context.Users.AsNoTracking().FirstOrDefaultAsync(
      u => string.Compare(u.Username, username, StringComparison.OrdinalIgnoreCase) == 0,
      cancellationToken
    );
  }

  public async Task SaveChangesAsync(CancellationToken cancellationToken)
  {
    await _context.SaveChangesAsync(cancellationToken);
  }
}