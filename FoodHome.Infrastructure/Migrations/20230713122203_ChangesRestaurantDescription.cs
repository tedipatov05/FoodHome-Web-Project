using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class ChangesRestaurantDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Dishes",
                type: "bit",
                nullable: false,
                comment: "Is active dish",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is actice dish");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "b391f858-3d1b-4a35-9807-6a57a3879238");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "ddf83845-5186-4689-b478-3151db92bfe5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "7c9a35e7-09dd-4fe0-8402-7a65a4adc540");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b80f8e1d-7c47-4dd8-a4d2-e30fca13b380", "AQAAAAEAACcQAAAAEFOhRHhvSpiEMfWyxA2RkH3pmJhYQZoJ7jMBJuhL8fDGS1WqqoIOcP28F1q4vdWBVg==", "86d2e72a-9f8f-48fe-af88-fb8f3831c3d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbed90aa-1cbe-4026-90f9-f1d374288ba5", "AQAAAAEAACcQAAAAEIOtBlAcCXsB0dryolyczCsdUk/0PYFF6dy+viaZNMVZJagLU6bVbKqSXMHb7pJjeA==", "eb368e5b-e661-46b5-a46a-e25271d910ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42a17901-05bd-4b11-9e1d-08fc20442785", "AQAAAAEAACcQAAAAEMdmq3MUrEHS7x39dfStwE2PwhB09WUXd6j3v+ZRaMLmReTMdLnwBnT7EhIdyMwcvw==", "84f9065e-b187-4d42-8e67-2221433ac464" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: "5e364b5e-8bc2-4e8d-a3f8-72f5776fbe9d",
                column: "Description",
                value: "Welcome to our restaurant, where the gourmet experience becomes a real symphony of flavors. Our establishment offers a cozy and sophisticated environment where you can enjoy the unique combination of culinary delights and refined drinks.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Dishes",
                type: "bit",
                nullable: false,
                comment: "Is actice dish",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is active dish");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "c2a859f9-3352-449d-8f10-bc1061ea22f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "2e6d08c4-220b-451f-a83e-89d689e213ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "e261af62-6924-47b0-a6c3-f1e694462082");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85c01392-e6a0-41ff-983e-f7c42ef06c4a", "AQAAAAEAACcQAAAAEIxL4NwpX/W60vNk4n2Jg4DJhjQ8zITxz3vv1v4BVAgl2G7heZW877wSRg8aCBs7cw==", "dcbc2049-1ce4-49e9-bc9a-5d456b5f943c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34b308e3-e0d4-4d00-9ead-7e96198e0ad0", "AQAAAAEAACcQAAAAEKoCwANN7kcbu2qekNzl8lmgRGg33Fhwsl8X8MzDuX0sy9E/RA2QNYOIP57vVaPnHQ==", "649851a9-968f-4448-9327-2c257d755859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a5dac4-4e24-4473-a6b6-1847722b9a37", "AQAAAAEAACcQAAAAEF/qOtGOdORkAPmodsNO2NAcc99oikH61yI+n5S8tvHfCb8RphVNOelZPXrrdNqnVA==", "7232218c-0b09-41ea-b9b9-437c0bb5b7ee" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: "5e364b5e-8bc2-4e8d-a3f8-72f5776fbe9d",
                column: "Description",
                value: "Добре дошли в нашия ресторант, където гурме изживяването се превръща в истинска симфония на вкусове. Нашето заведение предлага уютна и изискана обстановка, в която можете да се насладите на неповторимата комбинация от кулинарни изкушения и изискани напитки.");
        }
    }
}
