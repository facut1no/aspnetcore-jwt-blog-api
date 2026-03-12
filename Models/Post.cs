using System.Xml;

namespace PostCommentAPI.Models;

public sealed class Post
{
  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string ImageUrl { get; set; } = string.Empty;
  public bool IsDeleted { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public Guid UserId { get; set; }
  public User User { get; set; } = null!;
  public ICollection<PostLike> Likes { get; set; } = new List<PostLike>();
  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}