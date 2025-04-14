using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesosDatos.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email_Id",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Contrasenia_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Email_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
