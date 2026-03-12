namespace PostCommentAPI.Models;

public sealed class CommentLike
{
  public DateTime CreatedAt { get; set; }
  public Guid UserId { get; set; }
  public User User { get; set; } = null!;
  public Guid CommentId { get; set; }
  public Comment Comment { get; set; } = null!;
}