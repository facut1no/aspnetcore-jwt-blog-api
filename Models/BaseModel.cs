namespace PostCommentAPI.Models;

public abstract class BaseModel
{
  public bool IsDeleted { get; set; }
  public DateTime? DeletedTimeUtc { get; set; } = null!;
}