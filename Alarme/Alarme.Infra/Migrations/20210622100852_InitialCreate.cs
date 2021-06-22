using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alarme.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarmes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    NumeroSerie = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlarmesAtuados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdAlarme = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmesAtuados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmesAtuados_Alarmes_IdAlarme",
                        column: x => x.IdAlarme,
                        principalTable: "Alarmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmeEquipamentos",
                columns: table => new
                {
                    IdAlarme = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEquipamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TempId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmeEquipamentos", x => new { x.IdAlarme, x.IdEquipamento });
                    table.UniqueConstraint("AK_AlarmeEquipamentos_TempId", x => x.TempId);
                    table.ForeignKey(
                        name: "FK_AlarmeEquipamentos_Alarmes_IdAlarme",
                        column: x => x.IdAlarme,
                        principalTable: "Alarmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlarmeEquipamentos_Equipamentos_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmeEquipamentos_IdEquipamento",
                table: "AlarmeEquipamentos",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmesAtuados_IdAlarme",
                table: "AlarmesAtuados",
                column: "IdAlarme",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmeEquipamentos");

            migrationBuilder.DropTable(
                name: "AlarmesAtuados");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Alarmes");
        }
    }
}
