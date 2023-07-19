using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AllowNullToDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                comment: "Time for delivery",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Time for delivery");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dishes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                comment: "Description of the dish",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Description of the dish");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Time for delivery",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Time for delivery");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dishes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Description of the dish",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldComment: "Description of the dish");

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
    }
}
