using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Travel.Library.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfigDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BookId", "Lastname", "Name" },
                values: new object[,]
                {
                    { 1, null, "Author One", "First Name" },
                    { 2, null, "Author Two", "Second Name" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "HouseLocation", "Name" },
                values: new object[,]
                {
                    { 1, "Location test one", "First publisher" },
                    { 2, "Location test two", "Second publisher test" },
                    { 3, "Location test three", "Third publisher test" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PublishersId", "Synopsis", "Title" },
                values: new object[,]
                {
                    { 1, 1, "First book test synopsis", "First book" },
                    { 2, 3, "Second book test synopsis", "Second book" }
                });

            migrationBuilder.InsertData(
                table: "AuthorsBooks",
                columns: new[] { "AuthorsId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorsBooks",
                keyColumns: new[] { "AuthorsId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorsBooks",
                keyColumns: new[] { "AuthorsId", "BookId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorsBooks",
                keyColumns: new[] { "AuthorsId", "BookId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
