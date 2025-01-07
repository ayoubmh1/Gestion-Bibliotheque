using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class AjouterInfosClientDansEmprunt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientCin",
                table: "Emprunts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientNom",
                table: "Emprunts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCin",
                table: "Emprunts");

            migrationBuilder.DropColumn(
                name: "ClientNom",
                table: "Emprunts");
        }
    }
}
