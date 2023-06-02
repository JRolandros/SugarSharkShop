using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SugarShark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCartItemField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qantity",
                table: "CartItems",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "Qantity");
        }
    }
}
