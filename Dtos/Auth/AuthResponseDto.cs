using PostCommentAPI.Dtos.Users;

namespace PostCommentAPI.Dtos.Auth;

public sealed class AuthResponseDto
{
  public string AccessToken { get; set; } = string.Empty;

  public DateTime ExpiresAt { get; set; }

  public UserDto User { get; set; } = null!;
}