using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "dc1cb45f-b3e5-4444-8a3f-b43ad696f535");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "81b95c00-bbd7-4ffa-8215-3171c3ca1ce7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "7a7082ca-bd43-4d24-8fcb-a5b9ab05276b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b480f48e-280e-406e-86b4-b264c050e1fd", "AQAAAAEAACcQAAAAEJDn8M5YQkCzvAtDfDp70OW0l9B+x0YjDHuzWt9g3RMBdXam2/ZrRRxIE1ZxDaGXWA==", "985f648f-7720-4c03-a3ca-351d5f469c41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cfb6e35-eacd-4f22-b7f6-a59c0c31b5fd", "AQAAAAEAACcQAAAAEHWzMXzajB+SwrVN9UqWkNw/b5Bk1Hsk/YF7FkeeK6Y4ATdqtBhiYeaoFhkoC/wn0g==", "170c96b6-3e39-4495-81ac-31a1d6a7b784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a4dca81-9cd4-46ee-b62c-f50f9e530441", "AQAAAAEAACcQAAAAELKFjACDIeucUApYg96iblhX2Mp/x2spw8Z8NkrYGSJxpbCGtW/4O67YSMH00uaN8Q==", "3fd45b62-528c-4a67-91bc-b26f65eba865" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "e6b6d915-4add-4486-9a2a-509de33aee81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "7d6f0286-5897-4be7-bac1-8266e5baf65d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "3fe3ba26-179f-4c1e-8496-46eb30cb1de2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a43499b3-0f3b-44c0-9071-9a5524069397", "AQAAAAEAACcQAAAAEL8OiaDJ7oOfwdx2CfubBLSjOPQ9so0DX6i9HAzP5luRNP47s2gWubNhWKZduZ/gMw==", "3bb52162-ae98-44cc-a14a-72ca9899c446" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ee93ef7-27d6-41ac-b7f5-0b5d20d08330", "AQAAAAEAACcQAAAAEJzulPLnTgeLlm/ijicqhZjRT3iOtnQL4ard8kCf9Db29R5vFzgeTrMDPHiODz1xdQ==", "6d42db37-8dbf-494f-aa2a-5473fd63f76a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e492a908-0685-4788-ac71-1066a7ef31ef", "AQAAAAEAACcQAAAAECytXeIAf/98ubMYuFHIqzRei6DFlhQPWZT3Lc088j1cSPOuUAaervFufIfuRNsVQw==", "5106a126-bd76-475e-a459-774f1fbf66f5" });
        }
    }
}
