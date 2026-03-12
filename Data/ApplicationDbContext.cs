using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Post> Posts { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<CommentLike> CommentLikes { get; set; }
  public DbSet<PostLike> PostLikes { get; set; }
}