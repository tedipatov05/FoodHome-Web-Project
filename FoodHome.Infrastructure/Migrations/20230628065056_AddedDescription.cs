using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddedDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Description of the restaurant");

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

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: "5e364b5e-8bc2-4e8d-a3f8-72f5776fbe9d",
                column: "Description",
                value: "Добре дошли в нашия ресторант, където гурме изживяването се превръща в истинска симфония на вкусове. Нашето заведение предлага уютна и изискана обстановка, в която можете да се насладите на неповторимата комбинация от кулинарни изкушения и изискани напитки.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "92b6f4d6-0742-4f1d-9098-0bfda86e548b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "891dfc3e-82c9-477c-b8e7-2c001411c603");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "3f0527d8-9f72-4119-bee7-e90b61e9062f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e54fd6a1-f162-4a32-bb92-7ff23b3677a7", "AQAAAAEAACcQAAAAEBwW7kd872mV9Apb38dHCrvin0MIVV9M4JGMkdJUUV8IpzyYvb8iMyh646IOeRQqZQ==", "8c76fbfc-a3c5-401e-9e25-f4313f16800c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de389dd6-3cfe-4d25-bdc2-57763846e89a", "AQAAAAEAACcQAAAAEN34d6aLZ01A7+/V7lS1GIQ702PLm+AgeFGJot+QadR3Y3F04LC5KnhIVvdjdt6tyg==", "757bfffb-21eb-46c8-9504-3e219c2b189e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b644c5b0-1dd9-4f5a-8b5d-ce27bdaebe03", "AQAAAAEAACcQAAAAEKait6Bm2Tl9/eFteO/WyxxfxxK/hASoYZewhTX8JV6h5tUHpmF0ykpl2ON+Z5HqKQ==", "2717ecb1-f3cf-47fe-8caa-48f6934ea6bd" });
        }
    }
}
