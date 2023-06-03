using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SugarShark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValidityEndDate",
                value: new DateTime(2023, 6, 5, 0, 41, 43, 772, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ValidityEndDate",
                value: new DateTime(2023, 6, 5, 0, 41, 43, 772, DateTimeKind.Local).AddTicks(145));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValidityEndDate",
                value: new DateTime(2023, 6, 4, 14, 29, 24, 411, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ValidityEndDate",
                value: new DateTime(2023, 6, 4, 14, 29, 24, 411, DateTimeKind.Local).AddTicks(7860));
        }
    }
}
