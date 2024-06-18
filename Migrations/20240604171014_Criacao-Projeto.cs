using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoProcura.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalRaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalCor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalObservacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalDtDesaperecimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalDtEncontro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Observacoes",
                columns: table => new
                {
                    ObservacoesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservacoesDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacoesLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacoesData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacoes", x => x.ObservacoesId);
                    table.ForeignKey(
                        name: "FK_Observacoes_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_UsuarioId",
                table: "Animal",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_AnimalId",
                table: "Observacoes",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_UsuarioId",
                table: "Observacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observacoes");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
