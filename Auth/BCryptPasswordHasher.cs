namespace PostCommentAPI.Auth;

public sealed class BcryptPasswordHasher : IPasswordHasher
{
  public string HashPassword(string password)
  {
    if (string.IsNullOrWhiteSpace(password))
      throw new ArgumentException("Password cannot be empty", nameof(password));

    return BCrypt.Net.BCrypt.HashPassword(password);
  }

  public bool VerifyPassword(string password, string passwordHash)
  {
    return BCrypt.Net.BCrypt.Verify(password, passwordHash);
  }
}