using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoeAirlinesSenai.Migrations
{
    public partial class TipoManutencao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Manutencoes",
                newName: "TipoManutencao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoManutencao",
                table: "Manutencoes",
                newName: "Tipo");
        }
    }
}
