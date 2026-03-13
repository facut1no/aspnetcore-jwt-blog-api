using System.ComponentModel.DataAnnotations.Schema;

namespace PostCommentAPI.Models;

public sealed class User
{
  public Guid Id { get; set; }
  public string Username { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string PasswordHash { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  [NotMapped]
  public string FullName { get; set; } = string.Empty;
  public string? ProfileImageUrl { get; set; } = null!;
  public bool IsDeleted { get; set; }
  public bool IsActive { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime DeletedAt { get; set; }
  public ICollection<Post> Posts { get; set; } = new List<Post>();
  public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();
  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();
}