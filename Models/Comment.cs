namespace PostCommentAPI.Models;

public sealed class Comment
{
  public Guid Id { get; set; }
  public string Content { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public Guid? ParentCommentId { get; set; }
  public Comment? ParentComment { get; set; }
  public Guid PostId { get; set; }
  public Post Post { get; set; } = null!;
  public Guid UserId { get; set; }
  public User User { get; set; } = null!;

}