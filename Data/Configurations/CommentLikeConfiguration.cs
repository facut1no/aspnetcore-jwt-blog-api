using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data.Configurations;

public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
{
  public void Configure(EntityTypeBuilder<CommentLike> builder)
  {
    builder.HasKey(cl => new { cl.UserId, cl.CommentId });

    builder.Property(cl => cl.CreatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .ValueGeneratedOnAdd();

    builder.HasOne(cl => cl.User)
      .WithMany(u => u.CommentLikes)
      .HasForeignKey(cl => cl.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(cl => cl.Comment)
      .WithMany(c => c.Likes)
      .HasForeignKey(cl => cl.CommentId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasQueryFilter(cl => !cl.User.IsDeleted);
    builder.HasQueryFilter(cl => !cl.Comment.IsDeleted);

  }
}