using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snaspreact.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedContentModelmigratedcontentTypetopostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Content_ContentID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UrlContents_Content_ContentModelID",
                table: "UrlContents");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ContentID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ContentID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ContentModelID",
                table: "UrlContents",
                newName: "PostModelID");

            migrationBuilder.RenameIndex(
                name: "IX_UrlContents_ContentModelID",
                table: "UrlContents",
                newName: "IX_UrlContents_PostModelID");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UrlContents_Posts_PostModelID",
                table: "UrlContents",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlContents_Posts_PostModelID",
                table: "UrlContents");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostModelID",
                table: "UrlContents",
                newName: "ContentModelID");

            migrationBuilder.RenameIndex(
                name: "IX_UrlContents_PostModelID",
                table: "UrlContents",
                newName: "IX_UrlContents_ContentModelID");

            migrationBuilder.AddColumn<int>(
                name: "ContentID",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ContentID",
                table: "Posts",
                column: "ContentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Content_ContentID",
                table: "Posts",
                column: "ContentID",
                principalTable: "Content",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlContents_Content_ContentModelID",
                table: "UrlContents",
                column: "ContentModelID",
                principalTable: "Content",
                principalColumn: "ID");
        }
    }
}
