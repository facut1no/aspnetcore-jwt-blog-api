using System.ComponentModel.DataAnnotations;

namespace PostCommentAPI.Dtos;

public sealed class CreateCommentDto
{
  [Required]
  [MaxLength(500)]
  public string Content { get; set; } = null!;
}