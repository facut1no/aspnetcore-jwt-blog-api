namespace PostCommentAPI.Dtos.Auth;

using System.ComponentModel.DataAnnotations;

public sealed class LoginRequestDto
{
  [Required]
  public required string UserName { get; set; } = string.Empty;
  [Required]
  public required string Password { get; set; } = string.Empty;
}