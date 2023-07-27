using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddedFieldToPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardHolder",
                table: "Payments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Owner of the card");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "6c499191-96f7-4991-b45d-e632cfa54978");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "c8632719-ff89-4cc5-bdfe-c4ecfc1462a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "93bb3768-bcaa-42f7-8a0b-13e72aebb39b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7948354-e7e9-4b2f-8cb4-7a221b01ab45", "AQAAAAEAACcQAAAAEL6WZEpcgtRZJDE0D9uc0nJ8hxH+4Lbx7WYBscVrqmuyE2/tcNjXEyia04/OLwqfkw==", "a6c147aa-427d-443e-92c5-be8b9aa6f2bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3db295-4a20-4b23-a203-dd771992572d", "AQAAAAEAACcQAAAAEBaxUUPnlLRUdCswT/f730aldtMObz/ULcVij4F0EpUpc050CNz3VmKTz6i8U97hTQ==", "6dd9cc0a-b3bd-48ea-b4b9-0070bb78b00e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72c1fa67-7769-425e-85f3-df633bebc961", "AQAAAAEAACcQAAAAEK4jDK7k9CN5wtiRwBwi8PSUlOUVSuz2kos3W/TuTm6jCu9yfK4milzrldmVlKvw5Q==", "005d02e3-8b06-4a7f-8661-c27457ef3fab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardHolder",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "193fed87-45f0-4792-9d95-9b185d25175a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "deb0123e-596c-4f5c-a96c-19057f40b476");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "d70d840b-59d8-447f-b188-7f4cd535276a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7ae7927-f49f-424e-9848-07e6c298d79f", "AQAAAAEAACcQAAAAECMQ6k5Myq5NS7UiVwtG2MzCBua6eBLWlE2Ld9Am4m7xpJoQMZy6iXKBQJBvYbOCtA==", "1e7ca43d-70a3-4b34-9737-371fd40ec324" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8933ca40-7610-436c-88c5-7dbf975921ad", "AQAAAAEAACcQAAAAEPRQzG9veiOp6rCJm9+hvZmiIl1H+hBI3OOMjrHsNI3deHygxf4oAW9q7/TIApTZGA==", "972e5398-03e3-432e-ad16-6b1680083839" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4da9e86-ca9d-430a-b06c-493eeded14db", "AQAAAAEAACcQAAAAEFpugfZ+BPStVsWr4FPOWWNcOePboP9KfJPqkOj6RHPhNoR68pUEJk/XnARFggbvrA==", "580dff3d-cb80-4202-aacb-88e834d4b98c" });
        }
    }
}
