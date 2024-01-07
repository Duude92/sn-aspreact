using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snaspreact.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedappuserprofileImagename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profileImage",
                table: "AspNetUsers",
                newName: "ProfileImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "AspNetUsers",
                newName: "profileImage");
        }
    }
}
