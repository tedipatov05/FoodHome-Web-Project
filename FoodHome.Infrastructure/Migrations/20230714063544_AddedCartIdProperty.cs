using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddedCartIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Cart Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "d6671b8b-feee-422c-901c-3da9f406f9f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "6a1b8b7d-7394-4ed8-b497-732d9ebc4cc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "5aa13d57-c265-4f13-a093-c55e7d3b75bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd61ffac-ad99-4420-9288-ca3c17cb7f85", "AQAAAAEAACcQAAAAELCK30Bm/c1i1bP3udjhtnpl6knwvv8y3R/LIzdf9KF1vbPjqMoup4xv+4q1zJgd/g==", "df3cc1e7-0e8c-4c2e-81b8-6765dfe88246" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "201515d5-91a3-46a5-94ce-48240ef2aff5", "AQAAAAEAACcQAAAAEIZmADmLbWN9iQ2GxTton3S/a1N2RUR4+GEtqPCbt6etChRxa2n+uyBd8SULh5KCZw==", "6df44798-7650-4fa8-a57f-e5c1f3d96042" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a16f5027-3340-4c1f-884f-4ab257edb6d4", "AQAAAAEAACcQAAAAEN3qrC8DiRD+OSWfo7jfdiftaxfKdP+BhImDfXmIHDRk5Er4jADmcjIRkNhDW5jMWQ==", "9d9c6c91-67c4-4266-bb75-fb04f687268b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Dishes");

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
        }
    }
}
