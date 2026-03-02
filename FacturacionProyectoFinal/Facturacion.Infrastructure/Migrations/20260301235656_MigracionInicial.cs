using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fac");

            migrationBuilder.EnsureSchema(
                name: "Aut");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Aut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.CheckConstraint("CK_Usuarios_Email", "[Email] LIKE '%@%.%'");
                    table.CheckConstraint("CK_Usuarios_Nombre", "LEN([Nombre]) >= 2");
                    table.CheckConstraint("CK_Usuarios_UserName", "LEN([UserName]) >= 4");
                    table.ForeignKey(
                        name: "FK_Usuarios_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "Fac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.CheckConstraint("CK_Clientes_Edad", "[Edad] >= 0 AND [Edad] <= 150");
                    table.CheckConstraint("CK_Clientes_Email", "[Email] LIKE '%@%.%'");
                    table.CheckConstraint("CK_Clientes_Identificacion", "LEN([Identificacion]) >= 5");
                    table.CheckConstraint("CK_Clientes_Nombre", "LEN([Nombre]) >= 2");
                    table.ForeignKey(
                        name: "FK_Clientes_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clientes_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pantallas",
                schema: "Aut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RutaPantalla = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pantallas", x => x.Id);
                    table.CheckConstraint("CK_Pantallas_RutaPantalla", "[RutaPantalla] LIKE '/%'");
                    table.ForeignKey(
                        name: "FK_Pantallas_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pantallas_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "Fac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.CheckConstraint("CK_Productos_Nombre", "LEN([Nombre]) >= 2");
                    table.CheckConstraint("CK_Productos_Precio", "[Precio] > 0");
                    table.CheckConstraint("CK_Productos_Stock", "[Stock] >= 0");
                    table.ForeignKey(
                        name: "FK_Productos_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Aut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.CheckConstraint("CK_Roles_Nombre", "LEN([Nombre]) >= 2");
                    table.ForeignKey(
                        name: "FK_Roles_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                schema: "Fac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFactura = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.CheckConstraint("CK_Facturas_Impuesto", "[Impuesto] >= 0");
                    table.CheckConstraint("CK_Facturas_Subtotal", "[Subtotal] >= 0");
                    table.CheckConstraint("CK_Facturas_Total", "[Total] >= 0");
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes",
                        column: x => x.ClienteId,
                        principalSchema: "Fac",
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturas_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolesPantallas",
                schema: "Aut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PantallaId = table.Column<int>(type: "int", nullable: false),
                    PuederVer = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PuedeCrear = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PuedeEditar = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PuedeDeshabilitar = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPantallas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPantallas_Pantallas",
                        column: x => x.PantallaId,
                        principalSchema: "Aut",
                        principalTable: "Pantallas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesPantallas_Roles",
                        column: x => x.RolId,
                        principalSchema: "Aut",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesPantallas_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolesPantallas_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosRoles",
                schema: "Aut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Roles",
                        column: x => x.RolId,
                        principalSchema: "Aut",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuarios",
                        column: x => x.UsuarioId,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturasDetalles",
                schema: "Fac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasDetalles", x => x.Id);
                    table.CheckConstraint("CK_FacturasDetalles_Cantidad", "[Cantidad] >= 0");
                    table.CheckConstraint("CK_FacturasDetalles_PrecioUnitario", "[PrecioUnitario] >= 0");
                    table.CheckConstraint("CK_FacturasDetalles_SubTotal", "[SubTotal] >= 0");
                    table.ForeignKey(
                        name: "FK_FacturasDetalles_Facturas",
                        column: x => x.FacturaId,
                        principalSchema: "Fac",
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturasDetalles_Productos",
                        column: x => x.ProductoId,
                        principalSchema: "Fac",
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturasDetalles_UsuarioCrea",
                        column: x => x.UsuarioCreacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FacturasDetalles_UsuarioModf",
                        column: x => x.UsuarioModificacion,
                        principalSchema: "Aut",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioCreacion",
                schema: "Fac",
                table: "Clientes",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioModificacion",
                schema: "Fac",
                table: "Clientes",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_Clientes_Email",
                schema: "Fac",
                table: "Clientes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Clientes_Identificacion",
                schema: "Fac",
                table: "Clientes",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                schema: "Fac",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_UsuarioCreacion",
                schema: "Fac",
                table: "Facturas",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_UsuarioModificacion",
                schema: "Fac",
                table: "Facturas",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalles_FacturaId",
                schema: "Fac",
                table: "FacturasDetalles",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalles_ProductoId",
                schema: "Fac",
                table: "FacturasDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalles_UsuarioCreacion",
                schema: "Fac",
                table: "FacturasDetalles",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalles_UsuarioModificacion",
                schema: "Fac",
                table: "FacturasDetalles",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pantallas_UsuarioCreacion",
                schema: "Aut",
                table: "Pantallas",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pantallas_UsuarioModificacion",
                schema: "Aut",
                table: "Pantallas",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_Pantallas_Nombre",
                schema: "Aut",
                table: "Pantallas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Pantallas_RutaPantalla",
                schema: "Aut",
                table: "Pantallas",
                column: "RutaPantalla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioCreacion",
                schema: "Fac",
                table: "Productos",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioModificacion",
                schema: "Fac",
                table: "Productos",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_Productos_Nombre",
                schema: "Fac",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioCreacion",
                schema: "Aut",
                table: "Roles",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioModificacion",
                schema: "Aut",
                table: "Roles",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_Roles_Nombre",
                schema: "Aut",
                table: "Roles",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesPantallas_PantallaId",
                schema: "Aut",
                table: "RolesPantallas",
                column: "PantallaId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPantallas_UsuarioCreacion",
                schema: "Aut",
                table: "RolesPantallas",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPantallas_UsuarioModificacion",
                schema: "Aut",
                table: "RolesPantallas",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_RolesPantallas_RolPantalla",
                schema: "Aut",
                table: "RolesPantallas",
                columns: new[] { "RolId", "PantallaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioCreacion",
                schema: "Aut",
                table: "Usuarios",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioModificacion",
                schema: "Aut",
                table: "Usuarios",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuarios_Email",
                schema: "Aut",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_RolId",
                schema: "Aut",
                table: "UsuariosRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_UsuarioCreacion",
                schema: "Aut",
                table: "UsuariosRoles",
                column: "UsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_UsuarioModificacion",
                schema: "Aut",
                table: "UsuariosRoles",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "UQ_UsuariosRoles_UsuarioRol",
                schema: "Aut",
                table: "UsuariosRoles",
                columns: new[] { "UsuarioId", "RolId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturasDetalles",
                schema: "Fac");

            migrationBuilder.DropTable(
                name: "RolesPantallas",
                schema: "Aut");

            migrationBuilder.DropTable(
                name: "UsuariosRoles",
                schema: "Aut");

            migrationBuilder.DropTable(
                name: "Facturas",
                schema: "Fac");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "Fac");

            migrationBuilder.DropTable(
                name: "Pantallas",
                schema: "Aut");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Aut");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "Fac");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Aut");
        }
    }
}
