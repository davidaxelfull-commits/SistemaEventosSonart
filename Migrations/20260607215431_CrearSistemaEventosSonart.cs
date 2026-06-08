using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEventosSonart.Migrations
{
    /// <inheritdoc />
    public partial class CrearSistemaEventosSonart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "PaquetesServicio",
                columns: table => new
                {
                    PaqueteServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioBase = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaquetesServicio", x => x.PaqueteServicioId);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosAdicionales",
                columns: table => new
                {
                    ServicioAdicionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioReferencial = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosAdicionales", x => x.ServicioAdicionalId);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesEvento",
                columns: table => new
                {
                    SolicitudEventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoSolicitud = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesEvento", x => x.SolicitudEventoId);
                    table.ForeignKey(
                        name: "FK_SolicitudesEvento_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    CotizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudEventoId = table.Column<int>(type: "int", nullable: false),
                    PaqueteServicioId = table.Column<int>(type: "int", nullable: false),
                    FechaCotizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoCotizacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.CotizacionId);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_PaquetesServicio_PaqueteServicioId",
                        column: x => x.PaqueteServicioId,
                        principalTable: "PaquetesServicio",
                        principalColumn: "PaqueteServicioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_SolicitudesEvento_SolicitudEventoId",
                        column: x => x.SolicitudEventoId,
                        principalTable: "SolicitudesEvento",
                        principalColumn: "SolicitudEventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_PaqueteServicioId",
                table: "Cotizaciones",
                column: "PaqueteServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_SolicitudEventoId",
                table: "Cotizaciones",
                column: "SolicitudEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesEvento_ClienteId",
                table: "SolicitudesEvento",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "ServiciosAdicionales");

            migrationBuilder.DropTable(
                name: "PaquetesServicio");

            migrationBuilder.DropTable(
                name: "SolicitudesEvento");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
