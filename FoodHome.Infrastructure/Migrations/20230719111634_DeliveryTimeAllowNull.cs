using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class DeliveryTimeAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "4a232a56-985e-45bd-8929-f5d5091b70c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "2b1a8f4c-ad78-48df-a2c2-51d0008855b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "5d3e8bd6-6c51-4f57-b4e2-bf9ebe6baab3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d778ff34-caab-4ff5-95fd-d1b7f1cdd2bd", "AQAAAAEAACcQAAAAEO8Hfame+ehsmK3lr/9jyF5e2E1/66qmMnz8BE3gKbDbdNQpimdxurI5gwrC8CtZWg==", "a1974486-a174-4e73-8676-d3c66b9c3045" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c763ce06-829c-48bb-9841-23bf3d8fc9ad", "AQAAAAEAACcQAAAAEBfKZIDVZlo+ddkZHrCaX5n2UCeh+DrdgaO3apxdUTW86sTmK9m4Yt/174g9QDGV1Q==", "dc5c18c4-e180-4f0c-a428-7405f241dd61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "740c2166-f1c9-4973-b672-c51ebe11dd57", "AQAAAAEAACcQAAAAEIv4PiGKkW3QUsx+/Ss3VptnqHHeBfLLWs6uJ0YYN/wabBuTJ8N+/l0NuN0g68osFA==", "c37d7e62-7503-4086-bd7f-93ec7ddea254" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
