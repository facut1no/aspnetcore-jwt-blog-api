namespace PostCommentAPI.Dtos;

public sealed class ResponsePostDto
{
  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string? ImageUrl { get; set; } = null!;
  public DateTime CreateAt { get; set; }
  public DateTime UpdateAt { get; set; }
  public Guid UserId { get; set; }
}