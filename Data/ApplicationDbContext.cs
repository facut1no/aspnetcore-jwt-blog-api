using Microsoft.EntityFrameworkCore;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
    {
      if (entry.Properties.Any(p => p.Metadata.Name == "UpdatedAt"))
        entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
    }
    return base.SaveChangesAsync(cancellationToken);
  }

  public DbSet<Post> Posts { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<CommentLike> CommentLikes { get; set; }
  public DbSet<PostLike> PostLikes { get; set; }
}