using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snaspreact.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedprofilePicturetoidentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profileImage",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profileImage",
                table: "AspNetUsers");
        }
    }
}
