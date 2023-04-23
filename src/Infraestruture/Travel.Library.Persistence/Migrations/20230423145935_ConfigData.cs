using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Library.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfigData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BooksId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "Authors",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_BooksId",
                table: "Authors",
                newName: "IX_Authors_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookId",
                table: "Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Authors",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_BookId",
                table: "Authors",
                newName: "IX_Authors_BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BooksId",
                table: "Authors",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
