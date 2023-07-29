using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "User Address"),
                    City = table.Column<string>(type: "nvarchar(169)", maxLength: 169, nullable: false, comment: "User city"),
                    Country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false, comment: "User country"),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User profile picture url"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is active User"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "User");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Category of the dish");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary key"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Id"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is active Customer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Customer in the restaurant");

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary Key"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Id"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is active restaurant"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Description of the restaurant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Restaurant");

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Name of the dish"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category Id for the dish"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Description of the dish"),
                    Ingredients = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Ingredients of the dish"),
                    DishUrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image Url for the dish"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Price of the dish"),
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "RestaurantId"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Price of the dish"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is active dish")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                },
                comment: "Dish for the restaurant");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary key"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Order status"),
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Restaurant Id"),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Time order made"),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Time for delivery"),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Address fot delivery"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Customer Id"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Price of the order"),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "OrdersDishes",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Order Id"),
                    DishId = table.Column<int>(type: "int", nullable: false, comment: "Dish Id"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Ordered quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDishes", x => new { x.OrderId, x.DishId });
                    table.ForeignKey(
                        name: "FK_OrdersDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDishes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order Dish");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the payment"),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Time of payment"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the customer making payment"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Order Id"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Amount of payment"),
                    CardNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Number oif the card"),
                    CardHolder = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Owner of the card"),
                    ExpiryDate = table.Column<DateTime>(type: "DATE", nullable: false, comment: "Date of expiration"),
                    SecurityCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Security code of the card")
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a03f9f62-f106-4b1a-b1f9-eba622db3c92", "e252b259-8363-4606-948a-0ccc9a9173a4", "Customer", "CUSTOMER" },
                    { "a297aac9-aa64-4313-8c50-1d3cf7f379ba", "ac4f871f-7ad4-42e9-bf0a-a22b150df224", "Administrator", "ADMINISTRATOR" },
                    { "c34ebc61-94a5-40c5-a310-798532235d8e", "d336e9b4-3c45-4ece-9e1f-164c1ae4392a", "Restaurant", "RESTAURANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d9e1416-60a8-4655-af48-614ff829b230", 0, "ул. Ал. Батенберг 15 ет.5 ап.20", "Казанлък", "d717543a-bb45-4452-910f-a6cb5f0e88d4", "България", "tedipatov19@abv.bg", false, true, false, null, "Теодор Патов", "TEDIPATOV19@ABV.BG", "TEODOR", "AQAAAAEAACcQAAAAENZgxRshywa6Krr347kMSmAIJp6nRFhn+pS+h1DOQSDNxOsyKZt0ZedELX2+r9ojZg==", "0898392743", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1687251587/images/ap22312071681283-0d9c328f69a7c7f15320e8750d6ea447532dff66-s1100-c50_puo5bp.jpg", "581b6632-d016-49c2-8dd6-f06f49dcc956", false, "teodor" },
                    { "1d1f8115-ebb2-45e0-a375-cf713385ae9c", 0, "ул. Цар Освободител 21", "Казанлък", "8ec0b0c4-ac19-48f6-b8ca-c48569d848cf", "България", "vikifoods@abv.bg", false, true, false, null, "Viki Foods", "VIKIFOODS@ABV.BG", "VIKIFOODS", "AQAAAAEAACcQAAAAEJruyax3TLY0sL6fejyego1IJVkrltAIw6vuh0EvPryFcdTQWoODW1zWnzEsihyeSQ==", "0885732771", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1687252340/images/logo-no-background_yvrwc2.png", "1ef096fa-90e3-4410-8eb4-7364b5449fd9", false, "VikiFoods" },
                    { "d44500a1-526b-49d0-b373-05ac34baab0a", 0, "ул. Ал. Стамболийски 30 ет.3 ап.11", "Казанлък", "ab776057-f6ae-44fc-a8d3-72f35a10d447", "България", "ivonpatova@abv.bg", false, true, false, null, "Ивон Патова", "IVONPATOVA@ABV.BG", "IVON", "AQAAAAEAACcQAAAAEAsGf1k+ObncIF8SvY3qRecWXez/IAgqXI40vyh7ziq9OfiprMKqIYLCrto4jjPEVw==", "0887399847", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1687251175/images/photo-1574701148212-8518049c7b2c_zmlive.jpg", "1689d013-a12a-44b5-ab53-fd550b1fb9af", false, "ivon" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Предястия" },
                    { 2, "Ястия с месо" },
                    { 3, "Пици" },
                    { 4, "Салати" },
                    { 5, "Бургери" },
                    { 6, "Сандвичи" },
                    { 7, "Десерти" },
                    { 8, "Безалкохолни напитки" },
                    { 9, "Алкохолни напитки" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a297aac9-aa64-4313-8c50-1d3cf7f379ba", "0d9e1416-60a8-4655-af48-614ff829b230" },
                    { "c34ebc61-94a5-40c5-a310-798532235d8e", "1d1f8115-ebb2-45e0-a375-cf713385ae9c" },
                    { "a03f9f62-f106-4b1a-b1f9-eba622db3c92", "d44500a1-526b-49d0-b373-05ac34baab0a" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "IsActive", "UserId" },
                values: new object[] { "1f7e2314-f3a4-4ca1-b5e3-3a1bb8b6525a", true, "d44500a1-526b-49d0-b373-05ac34baab0a" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Description", "IsActive", "UserId" },
                values: new object[] { "5e364b5e-8bc2-4e8d-a3f8-72f5776fbe9d", "Welcome to our restaurant, where the gourmet experience becomes a real symphony of flavors. Our establishment offers a cozy and sophisticated environment where you can enjoy the unique combination of culinary delights and refined drinks.", true, "1d1f8115-ebb2-45e0-a375-cf713385ae9c" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDishes_DishId",
                table: "OrdersDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrdersDishes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
