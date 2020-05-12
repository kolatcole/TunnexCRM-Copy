using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Presentation.Core.Migrations
{
    public partial class _3rd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sales_InvoiceID",
                table: "Sales",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Invoices_InvoiceID",
                table: "Sales",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Invoices_InvoiceID",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_InvoiceID",
                table: "Sales");
        }
    }
}
