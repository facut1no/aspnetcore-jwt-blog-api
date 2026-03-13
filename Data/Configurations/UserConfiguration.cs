using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostCommentAPI.Models;

namespace PostCommentAPI.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(u => u.Id);

    builder.Property(u => u.Username)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(u => u.FirstName)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(u => u.LastName)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(u => u.Email)
      .IsRequired()
      .HasMaxLength(320);

    builder.Property(u => u.PasswordHash)
      .IsRequired();

    builder.Property(u => u.IsActive)
      .HasDefaultValue(true);

    builder.Property(u => u.IsDeleted)
      .HasDefaultValue(false);

    builder.Property(u => u.ProfileImageUrl)
      .HasMaxLength(500);

    builder.HasIndex(u => u.Username).IsUnique();
    builder.HasIndex(u => u.Email).IsUnique();

    builder.Property(u => u.DeletedAt)
      .HasDefaultValueSql("NULL");

    builder.Property(u => u.CreatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .ValueGeneratedOnAdd();

    builder.Property(u => u.UpdatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .ValueGeneratedOnAddOrUpdate();

    builder.HasMany(u => u.Posts)
      .WithOne(p => p.User)
      .HasForeignKey(p => p.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(u => u.Comments)
      .WithOne(c => c.User)
      .HasForeignKey(c => c.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(u => u.PostLikes)
      .WithOne(pl => pl.User)
      .HasForeignKey(pl => pl.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(u => u.CommentLikes)
      .WithOne(cl => cl.User)
      .HasForeignKey(cl => cl.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    // En un futuro mejorare esto para permitir recuperar la cuenta.
    builder.HasQueryFilter(u => !u.IsDeleted && u.IsActive);
  }

}