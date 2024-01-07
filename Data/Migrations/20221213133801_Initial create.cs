using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snaspreact.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostMessage = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    ContentID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Content",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UrlContents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    ContentModelID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlContents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UrlContents_Content_ContentModelID",
                        column: x => x.ContentModelID,
                        principalTable: "Content",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ContentID",
                table: "Posts",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_UrlContents_ContentModelID",
                table: "UrlContents",
                column: "ContentModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "UrlContents");

            migrationBuilder.DropTable(
                name: "Content");
        }
    }
}
