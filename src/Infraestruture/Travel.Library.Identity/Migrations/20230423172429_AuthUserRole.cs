using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Library.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AuthUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c662b0dc-ebab-4777-a751-28e402c2c624", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f63609b-808b-412c-93ed-6aab06cce828",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe49711e-59e6-49b5-9433-5a1b04b176ab", "AQAAAAIAAYagAAAAEAli3yTr3OkTUfTMTHSTSlGUOkbCy2zOy79VzK7/EDWPNUZ4PDazY+F14O55CdHezA==", "20b63008-8b87-4b79-be66-b46810ab4bde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c662b0dc-ebab-4777-a751-28e402c2c624");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f63609b-808b-412c-93ed-6aab06cce828",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2d1a9f5-516e-4ebb-af5d-75eee2f0b51c", "AQAAAAIAAYagAAAAEHlap4z/Np8pW5MtbUnHNAoaICMCWfmUJsFfbip4MStnILWjq+k+GmpL84p13Rnk0Q==", "199d6c40-7ab5-41c5-b17c-0619f164eec5" });
        }
    }
}
