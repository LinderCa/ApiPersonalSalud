using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPersonalSalud.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gestantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdadGestacional = table.Column<int>(type: "int", nullable: false),
                    GrupoSanguineo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestantes", x => x.Id);
                    table.CheckConstraint("CHK_CENGestante_Correo", "Correo LIKE '_%@_%._%'");
                    table.CheckConstraint("CHK_CENGestante_FechaNacimiento", "FechaNacimiento <= DATEADD(YEAR,-14,GETDATE())");
                    table.CheckConstraint("CHK_CENGestante_GrupoSanguineo", "GrupoSanguineo BETWEEN 0 AND 7");
                    table.CheckConstraint("CHK_CENGestante_Telefono", "Telefono IS NOT NULL OR (LEN(Telefono) = 9 AND Telefono NOT LIKE '%[^0-9]%')");
                });

            migrationBuilder.CreateTable(
                name: "PersonalSalud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalSalud", x => x.Id);
                    table.CheckConstraint("CHK_CENPersonalSalud_Especialidad", "Especialidad IN ('M','E','O')");
                });

            migrationBuilder.CreateTable(
                name: "AntecedentesMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGestante = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesMedicos", x => x.Id);
                    table.CheckConstraint("CHK_CenAntecedentesMedicos_Motivo", "Motivo BETWEEN 0 AND 3");
                    table.CheckConstraint("CHK_CENAntecedentesMedicos_Tipo", "Tipo BETWEEN 0 AND 2");
                    table.ForeignKey(
                        name: "FK_AntecedentesMedicos_Gestantes_IdGestante",
                        column: x => x.IdGestante,
                        principalTable: "Gestantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGestante = table.Column<int>(type: "int", nullable: false),
                    IdPersonalSalud = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraCita = table.Column<TimeSpan>(type: "time", nullable: false),
                    Motivo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.CheckConstraint("CHK_CENCita_Estado", "Estado BETWEEN 0 AND 2");
                    table.CheckConstraint("CHK_CENCita_FechaCita", "FechaCita >= GETDATE()");
                    table.CheckConstraint("CHK_CENCita_HoraCita", "HoraCita >= '08:00:00' AND HoraCita <= '15:00:00'");
                    table.CheckConstraint("CHK_CENCita_Motivo", "Motivo BETWEEN 0 AND 2");
                    table.ForeignKey(
                        name: "FK_Cita_Gestantes_IdGestante",
                        column: x => x.IdGestante,
                        principalTable: "Gestantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_PersonalSalud_IdPersonalSalud",
                        column: x => x.IdPersonalSalud,
                        principalTable: "PersonalSalud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGestante = table.Column<int>(type: "int", nullable: false),
                    IdPersonalSalud = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdReferencial = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.CheckConstraint("CHK_CENUsuario_Correo", "Correo LIKE '_%@_%._%'");
                    table.CheckConstraint("CHK_CENUsuario_Rol", "Rol BETWEEN 0 AND 3");
                    table.ForeignKey(
                        name: "FK_Usuario_Gestantes_IdGestante",
                        column: x => x.IdGestante,
                        principalTable: "Gestantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_PersonalSalud_IdPersonalSalud",
                        column: x => x.IdPersonalSalud,
                        principalTable: "PersonalSalud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Cita_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitoreo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    FechaMonitoreo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Proceso = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoreo", x => x.Id);
                    table.CheckConstraint("CHK_CENMonitoreo_Proceso", "Proceso IN (0,1)");
                    table.CheckConstraint("CHK_CENMonitoreo_Tipo", " Tipo IN (0,1)");
                    table.ForeignKey(
                        name: "FK_Monitoreo_Cita_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatosBiometricos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMonitoreo = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    PresionArterial = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaCardiaca = table.Column<int>(type: "int", nullable: false),
                    Temperatura = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosBiometricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosBiometricos_Monitoreo_IdMonitoreo",
                        column: x => x.IdMonitoreo,
                        principalTable: "Monitoreo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMonitoreo = table.Column<int>(type: "int", nullable: false),
                    Sintomas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoFetal = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Recomendacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                    table.CheckConstraint("CHK_CENDiagnostico_Estado", "Estado IN (0,1)");
                    table.CheckConstraint("CHK_CENDiagnostico_EstadoFetal", "EstadoFetal IN (0, 1)");
                    table.ForeignKey(
                        name: "FK_Diagnostico_Monitoreo_IdMonitoreo",
                        column: x => x.IdMonitoreo,
                        principalTable: "Monitoreo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesMedicos_IdGestante",
                table: "AntecedentesMedicos",
                column: "IdGestante");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdGestante",
                table: "Cita",
                column: "IdGestante");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdPersonalSalud",
                table: "Cita",
                column: "IdPersonalSalud");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdCita",
                table: "Consulta",
                column: "IdCita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatosBiometricos_IdMonitoreo",
                table: "DatosBiometricos",
                column: "IdMonitoreo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_IdMonitoreo",
                table: "Diagnostico",
                column: "IdMonitoreo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreo_IdCita",
                table: "Monitoreo",
                column: "IdCita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdGestante",
                table: "Usuario",
                column: "IdGestante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPersonalSalud",
                table: "Usuario",
                column: "IdPersonalSalud",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntecedentesMedicos");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "DatosBiometricos");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Monitoreo");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Gestantes");

            migrationBuilder.DropTable(
                name: "PersonalSalud");
        }
    }
}
