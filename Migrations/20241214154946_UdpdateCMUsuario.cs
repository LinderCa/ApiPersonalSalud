using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPersonalSalud.Migrations
{
    /// <inheritdoc />
    public partial class UdpdateCMUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_CENUsuario_Correo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdReferencial",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdReferencial",
                table: "Usuario",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CENUsuario_Correo",
                table: "Usuario",
                sql: "Correo LIKE '_%@_%._%'");
        }
    }
}
