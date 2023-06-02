using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SugarShark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId", "ValidityEndDate" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2023, 6, 4, 14, 29, 24, 411, DateTimeKind.Local).AddTicks(7817) },
                    { 4, 1, new DateTime(2023, 6, 4, 14, 29, 24, 411, DateTimeKind.Local).AddTicks(7860) }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AMBER" },
                    { 2, "DARK" },
                    { 3, "CLEAR" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, 11, 2 },
                    { 2, 2, 12, 1 },
                    { 3, 2, 13, 10 },
                    { 4, 4, 12, 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price", "ProductTypeId", "Stock" },
                values: new object[,]
                {
                    { 11, " Baby shark sugar cookies", "cookies-image-base64", "Cookies", 30.0, 1, 20 },
                    { 12, " Baby shark sugar Cakesicles", "Cakesicles-image-base64", "Cakesicles", 30.0, 1, 20 },
                    { 13, " Baby shark sugar cookies", "cookies-image-base64", "Cookies", 50.0, 2, 10 },
                    { 14, " Baby shark sugar cookies", "cookies-image-base64", "Cookies", 5.0, 3, 2 },
                    { 15, " shark sugar Cupcake", "Cupcake-image-base64", "Cupcake", 40.0, 3, 60 },
                    { 16, " Baby shark sugar Sprinkles", "Sprinkles-image-base64", "Sprinkles", 10.0, 3, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
