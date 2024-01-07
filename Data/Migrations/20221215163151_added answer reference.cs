using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snaspreact.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedanswerreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AnswerId",
                table: "Posts",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_AnswerId",
                table: "Posts",
                column: "AnswerId",
                principalTable: "Posts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_AnswerId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AnswerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Posts");
        }
    }
}
