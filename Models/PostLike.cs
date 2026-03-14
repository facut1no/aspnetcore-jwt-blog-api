namespace PostCommentAPI.Models;

public sealed class PostLike : BaseModel
{
  public DateTime CreatedAt { get; set; }
  public Guid UserId { get; set; }
  public User User { get; set; } = null!;
  public Guid PostId { get; set; }
  public Post Post { get; set; } = null!;
}