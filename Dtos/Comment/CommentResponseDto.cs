namespace PostCommentAPI.Dtos;

public sealed class CommentResponseDto
{
  public Guid Id { get; set; }
  public string Content { get; set; } = null!;

}