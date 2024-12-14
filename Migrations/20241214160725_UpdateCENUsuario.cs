using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPersonalSalud.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCENUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdGestante",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdPersonalSalud",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdPersonalSalud",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdGestante",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdGestante",
                table: "Usuario",
                column: "IdGestante",
                unique: true,
                filter: "[IdGestante] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPersonalSalud",
                table: "Usuario",
                column: "IdPersonalSalud",
                unique: true,
                filter: "[IdPersonalSalud] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdGestante",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdPersonalSalud",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdPersonalSalud",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdGestante",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
