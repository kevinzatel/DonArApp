using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    HistorialClinico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosBasicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tarea = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariosBasicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Especialidad = table.Column<int>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    Seguro = table.Column<string>(nullable: true),
                    InicioJornada = table.Column<int>(nullable: false),
                    FinJornada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariosMedicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PacienteId = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Sintomas = table.Column<string>(nullable: true),
                    Especialidad = table.Column<int>(nullable: true),
                    VoluntarioBasicoId = table.Column<int>(nullable: true),
                    VoluntarioMedicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_VoluntariosBasicos_VoluntarioBasicoId",
                        column: x => x.VoluntarioBasicoId,
                        principalTable: "VoluntariosBasicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_VoluntariosMedicos_VoluntarioMedicoId",
                        column: x => x.VoluntarioMedicoId,
                        principalTable: "VoluntariosMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_VoluntarioBasicoId",
                table: "Eventos",
                column: "VoluntarioBasicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_VoluntarioMedicoId",
                table: "Eventos",
                column: "VoluntarioMedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "VoluntariosBasicos");

            migrationBuilder.DropTable(
                name: "VoluntariosMedicos");
        }
    }
}
