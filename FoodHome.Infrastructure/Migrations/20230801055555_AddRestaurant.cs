using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "0bb08479-a24c-442f-b115-4a32e15c3ab8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "0e781253-2771-4f14-956f-90090984f072");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "6aaf5b4c-2c68-4d14-80ad-adc75e706f5b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4ebb71e-4e80-4f2c-9319-c40abb1b6915", "AQAAAAEAACcQAAAAED+Uogz8l9DxEVF6gQEvTEa+q8m9BF+ehqsbb4/ZUIopfkVPtAh6Fh237YFOpSb0IQ==", "54c45078-c3a3-404b-ad74-e24febc0dfdd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b15fe713-dc0b-4eaa-b078-4bc4d90c09a3", "AQAAAAEAACcQAAAAEBA4Xnr+jGApROLU7LLKoaSHdKTGvCyO0D93BiwcfnsWsMqf37COGqyUROzmz9mStQ==", "5d2fd481-5584-41d4-afac-bcef9ba5ccbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "826cec01-ca93-4cf3-9ab7-2528c946794d", "AQAAAAEAACcQAAAAEJn4Qsu/kpKWpcYk84ErIy9wTj9PVJgS5X4aR+ihdmaVirBQYBSoJGvUiYrl9yEPWg==", "cd23a744-51fb-470a-80b8-95e966239bda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
