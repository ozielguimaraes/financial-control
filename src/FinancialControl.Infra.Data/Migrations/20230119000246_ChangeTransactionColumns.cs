using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialControl.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTransactionColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Transactions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "CashierAccountId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CashierId",
                table: "CashierAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Category_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CashierAccountId",
                table: "Transactions",
                column: "CashierAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CashierAccounts_CashierId",
                table: "CashierAccounts",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubCategoryId",
                table: "Category",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashierAccounts_Cashiers_CashierId",
                table: "CashierAccounts",
                column: "CashierId",
                principalTable: "Cashiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CashierAccounts_CashierAccountId",
                table: "Transactions",
                column: "CashierAccountId",
                principalTable: "CashierAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Category_CategoryId",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashierAccounts_Cashiers_CashierId",
                table: "CashierAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CashierAccounts_CashierAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Category_CategoryId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CashierAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_CashierAccounts_CashierId",
                table: "CashierAccounts");

            migrationBuilder.DropColumn(
                name: "CashierAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CashierId",
                table: "CashierAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
