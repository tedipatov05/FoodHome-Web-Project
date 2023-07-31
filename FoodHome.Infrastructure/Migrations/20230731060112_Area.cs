using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class Area : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "d6a25c34-2994-4c26-9020-de6ae366f37d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "043b7791-69ea-45c1-b08c-afd9c10b8885");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "5a88f61c-b306-49ff-9fd1-3f06fc3f84a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c9a4611-ea3b-48a7-991b-481d69976dd0", "AQAAAAEAACcQAAAAEIdrJffrC04yQCClsI1is2FPYWgpW1nKzOs3dMQ6N+1aNsST0hhzHnFHbk48jMGcgg==", "96402ba9-1b00-4415-94b2-0cffd159451e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24e963b0-03c3-4908-9dba-c7fa661ba273", "AQAAAAEAACcQAAAAECUKAu3GJ20EYANCgNWCX7avFiYkoyjqTqqeMQW7lplctMEcgi9AQsRhT+9f2Ba+yA==", "9b0d189f-443f-4f25-ac79-05fb6e473ab6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5904044e-adc8-48ac-990d-40f9399ade78", "AQAAAAEAACcQAAAAEBsZ4slGY+QRs+lDfk5gqHINlcIVedkgv/aQB7nXz5LvuxtkrESJ18kwDImLCW4pDw==", "23b2dffd-508d-401c-b4e4-cbdb340a3fa1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "e252b259-8363-4606-948a-0ccc9a9173a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "ac4f871f-7ad4-42e9-bf0a-a22b150df224");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "d336e9b4-3c45-4ece-9e1f-164c1ae4392a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d717543a-bb45-4452-910f-a6cb5f0e88d4", "AQAAAAEAACcQAAAAENZgxRshywa6Krr347kMSmAIJp6nRFhn+pS+h1DOQSDNxOsyKZt0ZedELX2+r9ojZg==", "581b6632-d016-49c2-8dd6-f06f49dcc956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ec0b0c4-ac19-48f6-b8ca-c48569d848cf", "AQAAAAEAACcQAAAAEJruyax3TLY0sL6fejyego1IJVkrltAIw6vuh0EvPryFcdTQWoODW1zWnzEsihyeSQ==", "1ef096fa-90e3-4410-8eb4-7364b5449fd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab776057-f6ae-44fc-a8d3-72f35a10d447", "AQAAAAEAACcQAAAAEAsGf1k+ObncIF8SvY3qRecWXez/IAgqXI40vyh7ziq9OfiprMKqIYLCrto4jjPEVw==", "1689d013-a12a-44b5-ab53-fd550b1fb9af" });
        }
    }
}
