using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialControl.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingDescriptionToCashier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cashiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cashiers");
        }
    }
}
