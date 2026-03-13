using PostCommentAPI.Auth;
using PostCommentAPI.Dtos.Auth;

namespace PostCommentAPI.Services;

public sealed class AuhtService(IPasswordHasher passwordHasher) : IAuhtService
{
  private readonly IPasswordHasher _passwordHasher = passwordHasher;

  public Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
  {
    throw new NotImplementedException();
  }

  public Task LogoutAsync(Guid userId)
  {
    throw new NotImplementedException();
  }

  public Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
  {
    throw new NotImplementedException();
  }

  public Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
  {
    throw new NotImplementedException();
  }
}