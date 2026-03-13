using PostCommentAPI.Dtos.Auth;

namespace PostCommentAPI.Services;

public interface IAuhtService
{
  Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);

  Task<AuthResponseDto> LoginAsync(LoginRequestDto request);

  Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);

  Task LogoutAsync(Guid userId);
}