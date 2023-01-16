using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capta.Migrations
{
    public partial class AlterClientDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Document",
                table: "Clients",
                column: "Document",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Document",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
