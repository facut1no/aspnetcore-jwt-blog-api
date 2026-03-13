namespace PostCommentAPI.Dtos.Auth;

using System.ComponentModel.DataAnnotations;

public sealed class LoginRequestDto
{
  [Required]
  public required string Login { get; set; } = string.Empty;// Email o username. ;P
  [Required]
  public required string Password { get; set; } = string.Empty;
}