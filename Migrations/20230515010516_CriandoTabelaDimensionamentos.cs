using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dimensiona.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaDimensionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dimensionamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comprimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Largura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfundidadeMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfundidadeMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsoPiscina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensionamentos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimensionamentos");
        }
    }
}
