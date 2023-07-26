using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddedPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the payment"),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Time of payment"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the customer making payment"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Order Id"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Amount of payment"),
                    CardNumber = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false, comment: "Number oif the card"),
                    ExpiryDate = table.Column<DateTime>(type: "DATE", nullable: false, comment: "Date of expiration"),
                    SecurityCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Security code of the card"),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "ZIP code")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                },
                comment: "Payment for the order");

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "dc1cb45f-b3e5-4444-8a3f-b43ad696f535");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                column: "ConcurrencyStamp",
                value: "81b95c00-bbd7-4ffa-8215-3171c3ca1ce7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "7a7082ca-bd43-4d24-8fcb-a5b9ab05276b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d9e1416-60a8-4655-af48-614ff829b230",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b480f48e-280e-406e-86b4-b264c050e1fd", "AQAAAAEAACcQAAAAEJDn8M5YQkCzvAtDfDp70OW0l9B+x0YjDHuzWt9g3RMBdXam2/ZrRRxIE1ZxDaGXWA==", "985f648f-7720-4c03-a3ca-351d5f469c41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cfb6e35-eacd-4f22-b7f6-a59c0c31b5fd", "AQAAAAEAACcQAAAAEHWzMXzajB+SwrVN9UqWkNw/b5Bk1Hsk/YF7FkeeK6Y4ATdqtBhiYeaoFhkoC/wn0g==", "170c96b6-3e39-4495-81ac-31a1d6a7b784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d44500a1-526b-49d0-b373-05ac34baab0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a4dca81-9cd4-46ee-b62c-f50f9e530441", "AQAAAAEAACcQAAAAELKFjACDIeucUApYg96iblhX2Mp/x2spw8Z8NkrYGSJxpbCGtW/4O67YSMH00uaN8Q==", "3fd45b62-528c-4a67-91bc-b26f65eba865" });
        }
    }
}
