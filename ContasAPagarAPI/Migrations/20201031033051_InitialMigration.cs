using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContasAPagarAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 120, nullable: false),
                    ValorOriginal = table.Column<double>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    ValorCorrigido = table.Column<double>(nullable: false),
                    QuantidadeDiasAtraso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
