using PostCommentAPI.Common.Result;
using PostCommentAPI.Dtos.Auth;

namespace PostCommentAPI.Services;

public interface IAuhtService
{
  Task<Result<AuthResponseDto>> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken);

  Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);

  Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken);

  Task LogoutAsync(Guid userId);
}