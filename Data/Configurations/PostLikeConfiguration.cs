using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data.Configurations;

public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
  public void Configure(EntityTypeBuilder<PostLike> builder)
  {
    builder.HasKey(cl => new { cl.UserId, cl.PostId });

    builder.Property(cl => cl.CreatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .ValueGeneratedOnAdd();

    builder.HasOne(cl => cl.User)
      .WithMany(u => u.PostLikes)
      .HasForeignKey(cl => cl.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(cl => cl.Post)
      .WithMany(c => c.Likes)
      .HasForeignKey(cl => cl.PostId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasIndex(pl => pl.PostId);
    builder.HasIndex(pl => pl.UserId);

    builder.HasQueryFilter(pl => !pl.User.IsDeleted);
    builder.HasQueryFilter(pl => !pl.Post.IsDeleted);
  }
}