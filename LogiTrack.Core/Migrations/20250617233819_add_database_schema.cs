using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogiTrack.Core.Migrations
{
    /// <inheritdoc />
    public partial class add_database_schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    CodigoBarras = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovimentosEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataMovimento = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Usuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentosEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentosEstoque_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Ativa", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, true, "Produtos eletrônicos e informática", "Eletrônicos" },
                    { 2, true, "Materiais de escritório e papelaria", "Papelaria" },
                    { 3, true, "Produtos para casa e jardim", "Casa e Jardim" },
                    { 4, true, "Vestuário em geral", "Roupas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "CategoriaId", "CodigoBarras", "DataCadastro", "DataUltimaAtualizacao", "Descricao", "Nome", "Preco", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { 1, true, 1, "7891234567890", new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4021), null, "Notebook Dell Inspiron 15 - Intel i5, 8GB RAM, 256GB SSD", "Notebook Dell Inspiron", 2500.00m, 5 },
                    { 2, true, 1, "7891234567891", new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4026), null, "Mouse sem fio Logitech MX Master 3", "Mouse Logitech MX", 299.90m, 15 },
                    { 3, true, 1, "7891234567892", new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4030), null, "Teclado mecânico RGB com switches Cherry MX", "Teclado Mecânico Gamer", 450.00m, 8 },
                    { 4, true, 2, "7891234567893", new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4034), null, "Caneta esferográfica azul BIC Cristal", "Caneta BIC Cristal", 1.50m, 200 },
                    { 5, true, 2, "7891234567894", new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4038), null, "Caderno universitário 200 folhas", "Caderno Universitário", 15.90m, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentosEstoque_ProdutoId_DataMovimento",
                table: "MovimentosEstoque",
                columns: new[] { "ProdutoId", "DataMovimento" });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarras",
                table: "Produtos",
                column: "CodigoBarras",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Nome",
                table: "Produtos",
                column: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentosEstoque");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
