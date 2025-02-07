using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "239b05c4-79d2-4758-a935-0b03ffbf5c90", "8b387111-532b-4541-9d0d-c6ef01f7dbd8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6624a5ac-34ac-4c53-baad-841bfb0c2a01", "40c96411-97b3-4a07-8549-0404a2c25052", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "831d4006-6a40-4d2d-a7ac-e7f0cf90bdfa", "357ea084-abe5-42a7-b084-4b3fa97c5eef", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239b05c4-79d2-4758-a935-0b03ffbf5c90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6624a5ac-34ac-4c53-baad-841bfb0c2a01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "831d4006-6a40-4d2d-a7ac-e7f0cf90bdfa");
        }
    }
}
