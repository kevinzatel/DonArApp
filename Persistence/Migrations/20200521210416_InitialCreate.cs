using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoluntariosBasicos");

            migrationBuilder.DropTable(
                name: "VoluntariosMedicos");
        }
    }
}
