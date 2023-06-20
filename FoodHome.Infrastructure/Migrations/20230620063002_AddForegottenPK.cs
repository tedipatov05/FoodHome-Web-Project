using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    public partial class AddForegottenPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Restaurants",
                comment: "Restaurant");

            migrationBuilder.AlterTable(
                name: "RestaurantDishes",
                comment: "Restaurant dish");

            migrationBuilder.AlterTable(
                name: "OrdersDishes",
                comment: "Order Dish");

            migrationBuilder.AlterTable(
                name: "Orders",
                comment: "Order");

            migrationBuilder.AlterTable(
                name: "Dishes",
                comment: "Dish for the restaurant");

            migrationBuilder.AlterTable(
                name: "Customers",
                comment: "Customer in the restaurant");

            migrationBuilder.AlterTable(
                name: "Categories",
                comment: "Category of the dish");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                comment: "Is active restaurant",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Primary Key",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "RestaurantDishes",
                type: "int",
                nullable: false,
                comment: "Dish Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "RestaurantDishes",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Restaurant Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrdersDishes",
                type: "int",
                nullable: false,
                comment: "Ordered quantity",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "OrdersDishes",
                type: "int",
                nullable: false,
                comment: "Dish Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "OrdersDishes",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Order Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Order status",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Restaurant Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                comment: "Price of the order",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                comment: "Time order made",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                comment: "Time for delivery",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Address fot delivery",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Customer Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Dishes",
                type: "int",
                nullable: false,
                comment: "Price of the dish",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                comment: "Price of the dish",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "Name of the dish",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Dishes",
                type: "bit",
                nullable: false,
                comment: "Is actice dish",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "Dishes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Ingredients of the dish",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "DishUrlImage",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Image Url for the dish",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dishes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Description of the dish",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Dishes",
                type: "int",
                nullable: false,
                comment: "Category Id for the dish",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dishes",
                type: "int",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                comment: "Is active Customer",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Name of the category",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                comment: "Primary key ",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User profile picture url",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                comment: "Is active User",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                comment: "User country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(169)",
                maxLength: 169,
                nullable: false,
                comment: "User city",
                oldClrType: typeof(string),
                oldType: "nvarchar(169)",
                oldMaxLength: 169);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "User Address",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Restaurants",
                oldComment: "Restaurant");

            migrationBuilder.AlterTable(
                name: "RestaurantDishes",
                oldComment: "Restaurant dish");

            migrationBuilder.AlterTable(
                name: "OrdersDishes",
                oldComment: "Order Dish");

            migrationBuilder.AlterTable(
                name: "Orders",
                oldComment: "Order");

            migrationBuilder.AlterTable(
                name: "Dishes",
                oldComment: "Dish for the restaurant");

            migrationBuilder.AlterTable(
                name: "Customers",
                oldComment: "Customer in the restaurant");

            migrationBuilder.AlterTable(
                name: "Categories",
                oldComment: "Category of the dish");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User Id");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is active restaurant");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Primary Key");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "RestaurantDishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Dish Id");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "RestaurantDishes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Restaurant Id");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrdersDishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Ordered quantity");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "OrdersDishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Dish Id");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "OrdersDishes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Order Id");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Order status");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Restaurant Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComment: "Price of the order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Time order made");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Time for delivery");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Address fot delivery");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Customer Id");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Primary key");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Price of the dish");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComment: "Price of the dish");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "Name of the dish");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Dishes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is actice dish");

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "Dishes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Ingredients of the dish");

            migrationBuilder.AlterColumn<string>(
                name: "DishUrlImage",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Image Url for the dish");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dishes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Description of the dish");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Category Id for the dish");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User Id");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is active Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Primary key");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Name of the category");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key ")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User profile picture url");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is active User");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldComment: "User country");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(169)",
                maxLength: 169,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(169)",
                oldMaxLength: 169,
                oldComment: "User city");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "User Address");
        }
    }
}
