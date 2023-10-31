using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d3e2ff1-2604-4514-9929-6e77b3eb0313", "aa2cdbc2-cdde-475f-9659-d9774cfe51d7", "Administrator", "ADMINISTRATOR" },
                    { "b65a0dba-4d6c-4dc6-93a7-d20e6077af55", "073c52ba-502b-49c5-9dbb-440e5cf05f31", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d3e2ff1-2604-4514-9929-6e77b3eb0313");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b65a0dba-4d6c-4dc6-93a7-d20e6077af55");
        }
    }
}
