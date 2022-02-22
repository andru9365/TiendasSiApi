using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendasSiApi.Migrations
{
    public partial class DbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiendasSiProducto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detalleProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idTipoProducto = table.Column<int>(type: "int", nullable: false),
                    estadoProducto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiendasSiProducto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiendasSiTipoProducto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTipoProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoTipoProducto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiendasSiTipoProducto", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiendasSiProducto");

            migrationBuilder.DropTable(
                name: "TiendasSiTipoProducto");
        }
    }
}
