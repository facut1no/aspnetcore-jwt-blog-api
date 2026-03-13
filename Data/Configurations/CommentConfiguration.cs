using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.HasKey(c => c.Id);

    builder.Property(c => c.Content)
      .IsRequired()
      .HasMaxLength(500);

    builder.HasOne(c => c.User)
      .WithMany(u => u.Comments)
      .HasForeignKey(c => c.UserId);

    builder.Property(c => c.IsDeleted).HasDefaultValue(false);

    builder.HasOne(c => c.Post)
      .WithMany(p => p.Comments)
      .HasForeignKey(c => c.PostId);

    builder.HasOne(c => c.ParentComment)
      .WithMany(pc => pc.Replies)
      .HasForeignKey(c => c.ParentCommentId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasMany(c => c.Likes)
      .WithOne(cl => cl.Comment)
      .HasForeignKey(cl => cl.CommentId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasQueryFilter(c => !c.User.IsDeleted);
    builder.HasQueryFilter(c => !c.Post.IsDeleted);
  }
}