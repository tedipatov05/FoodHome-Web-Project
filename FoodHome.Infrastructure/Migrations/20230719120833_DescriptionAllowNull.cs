using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class DescriptionAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "561be098-8912-4d89-ab4f-b0d7991bd332");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "4ac35da2-b7e2-498b-9ada-404429a3f269");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "ca86ac52-efdb-45e2-a7ec-6e34e254c404");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ad4ed36-c6c9-4066-87f4-86fa998aa11f", "AQAAAAEAACcQAAAAEJW/3okZ/t2wJnp011/P66YFRT889/Rd45Y4o9YbZiGFLiT6+SioJVt2v9aKjK9hMw==", "fa69f7d5-0ee9-476d-9f54-7b86106f69cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9c4db94-d630-4bbd-8c78-a011b9675e82", "AQAAAAEAACcQAAAAEM7XF+vAqJHhPEHZjtjFRSJvU6FBNgF2kyEF3FipAAA/1XIwJN+Q7jcdh3jpG/2vBg==", "922b1bf3-3693-42cd-94dc-38acdfdc224d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d59a3970-fb5e-47ec-ae1d-1198e51e34b2", "AQAAAAEAACcQAAAAELJYXbLI6IRYLgt4Lx7UvPmsMIywR4Owv2ktAuayW0tO9dDffUGEgtBu1nwAOwoMWg==", "36eb3722-9c67-452b-affc-939c4d8b7e5e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
