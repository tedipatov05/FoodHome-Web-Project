using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class SeedSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "53f98f74-0490-465b-9531-287fcd7efcf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "986c88b3-2bbc-4d60-9dfc-84afc0b0b129");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "57f9d11d-ce48-40f0-a6e5-8615a1ed0ab4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfbeb3fa-d1c5-4668-8e1d-a20b63a4bda4", "AQAAAAEAACcQAAAAEOjwHIxfktQr15JK4xkcGXiPx7BEpD+B/EUpOSbFwlJMVyLPCTfYTQWKg6P+GsE2tQ==", "53a0f0f2-464b-4b17-8e94-1cd8d8b1387f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42dec8f5-7c2b-4e06-bf9d-70aa1caf2e6b", "AQAAAAEAACcQAAAAEIifVbRjhILrFVD4UzJpd8BxORbWqsAyX6SYs/9Ij1Y5Pv52GFCB1QW2E/cRziaquw==", "100f2543-b508-4482-9a0d-33ce13ebdf0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44620ab9-4bb8-4eef-a88a-5cf36c4defc3", "AQAAAAEAACcQAAAAEExWtzs243uYVNTgR4JKAd3veedh5QyBKjXLTpP+SXeq2CIn4vqtY0jMWTic0hdj0w==", "d073d92b-06be-45dd-8890-23b0cdd8f56b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "94c63f8c-35c6-46d9-beed-670b9913849d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "f763ff5f-5db6-413a-87b1-d4ca06803943");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "b177c8d4-ee97-42f5-8ed9-73d987b4c605");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5933f316-dd8b-4e6a-8084-17141fe97a1b", "AQAAAAEAACcQAAAAEEIG1KkTHSti4educUwijOu4Wzm9pb947kVt3UOVa4QsP3hSf7OPoeMWN5XHGEr1Kw==", "a103aeba-e19e-47f7-8206-df77143e6123" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "261cf006-5b17-4d02-95ee-4579781ed40d", "AQAAAAEAACcQAAAAEE6PW/BsoehIeqeGFcC6ACIF52y7vXuZEyuwI5qfNSMA8emBazo5p1jv0b5KFeGoEQ==", "250de74f-64bc-43bc-a2d5-bd31bb76b6b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ccc6b06-8d75-4f34-8715-859d17b4e444", "AQAAAAEAACcQAAAAEAEuLJqfEbq4OLrgCPDmhAqkgYNcPLV59QpOmrVjhXFIDx/Bm8tGFsPS1WAyrOPj/Q==", "11e11a33-d078-4bf5-b4f8-9dab1fa38c87" });
        }
    }
}
