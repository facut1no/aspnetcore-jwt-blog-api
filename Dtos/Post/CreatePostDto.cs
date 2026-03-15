namespace PostCommentAPI.Dtos;

public sealed class CreatePostDto
{
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string ImageUrl { get; set; } = string.Empty;
}