using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
  public void Configure(EntityTypeBuilder<Post> builder)
  {
    builder.HasKey(p => p.Id);

    builder.HasIndex(p => p.Title);
    builder.HasIndex(p => p.UserId);

    builder.Property(p => p.Title)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(p => p.Content)
      .IsRequired();

    builder.Property(p => p.ImageUrl)
      .HasMaxLength(500);

    builder.Property(p => p.IsDeleted)
      .HasDefaultValue(false);

    builder.Property(p => p.CreatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .ValueGeneratedOnAdd();

    builder.Property(p => p.UpdatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .ValueGeneratedOnAddOrUpdate();

    builder.HasOne(p => p.User)
      .WithMany(u => u.Posts)
      .HasForeignKey(p => p.UserId);

    builder.HasMany(p => p.Comments)
      .WithOne(c => c.Post)
      .HasForeignKey(c => c.PostId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(p => p.Likes)
      .WithOne(l => l.Post)
      .HasForeignKey(l => l.PostId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}