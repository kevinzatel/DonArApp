using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    TipoUsuarioId = table.Column<int>(nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    NacionalidadId = table.Column<int>(nullable: false),
                    TerminosyCondiciones = table.Column<bool>(nullable: false),
                    HistorialClinico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosBasicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    TipoUsuarioId = table.Column<int>(nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    NacionalidadId = table.Column<int>(nullable: false),
                    TerminosyCondiciones = table.Column<bool>(nullable: false)
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
                    Email = table.Column<string>(nullable: true),
                    TipoUsuarioId = table.Column<int>(nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    NacionalidadId = table.Column<int>(nullable: false),
                    TerminosyCondiciones = table.Column<bool>(nullable: false),
                    EspecialidadId = table.Column<int>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    Seguro = table.Column<string>(nullable: true),
                    InicioJornada = table.Column<string>(nullable: true),
                    FinJornada = table.Column<string>(nullable: true)
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
                    Fecha = table.Column<string>(nullable: true),
                    Seguimiento = table.Column<bool>(nullable: false),
                    EspecialidadId = table.Column<int>(nullable: true),
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
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");

            migrationBuilder.DropTable(
                name: "VoluntariosBasicos");

            migrationBuilder.DropTable(
                name: "VoluntariosMedicos");
        }
    }
}
