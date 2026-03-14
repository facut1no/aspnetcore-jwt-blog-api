using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostCommentAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NULL");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "Posts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "PostLikes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostLikes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "CommentLikes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CommentLikes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CommentLikes");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NULL");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
