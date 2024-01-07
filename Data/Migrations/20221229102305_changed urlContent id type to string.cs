using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snaspreact.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedurlContentidtypetostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlContents_Posts_PostModelID",
                table: "UrlContents");

            migrationBuilder.AlterColumn<int>(
                name: "PostModelID",
                table: "UrlContents",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "UrlContents",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

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

            migrationBuilder.AlterColumn<int>(
                name: "PostModelID",
                table: "UrlContents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "UrlContents",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_UrlContents_Posts_PostModelID",
                table: "UrlContents",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
