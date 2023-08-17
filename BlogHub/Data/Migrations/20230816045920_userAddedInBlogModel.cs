using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class userAddedInBlogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "blogModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "blogModels");
        }
    }
}
