using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dimensiona.Migrations
{
    /// <inheritdoc />
    public partial class RecriandoTabelaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Usuario");
        }
    }
}
