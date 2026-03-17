namespace PostCommentAPI.Dtos;

public sealed class UpdatePostDto
{
  public string? Title { get; set; } = null!;
  public string? Content { get; set; } = null!;
  public IFormFile? ImageFile { get; set; } = null!;
}