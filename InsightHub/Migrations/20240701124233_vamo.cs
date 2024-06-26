﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsightHub.Migrations
{
    /// <inheritdoc />
    public partial class vamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaConhecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaConhecimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubareaConhecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    AreaConhecimentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubareaConhecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubareaConhecimento_AreaConhecimento_AreaConhecimentoId",
                        column: x => x.AreaConhecimentoId,
                        principalTable: "AreaConhecimento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pesquisador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    SubareaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                        column: x => x.SubareaId,
                        principalTable: "SubareaConhecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DescricaoCurta = table.Column<string>(type: "text", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: false),
                    SubareaId = table.Column<int>(type: "integer", nullable: false),
                    Pesquisadores = table.Column<List<int>>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeto_SubareaConhecimento_SubareaId",
                        column: x => x.SubareaId,
                        principalTable: "SubareaConhecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: false),
                    ProjetoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captacao_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    ProjetoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producao_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoPesquisadorPivot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjetoId = table.Column<int>(type: "integer", nullable: false),
                    PesquisadorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoPesquisadorPivot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetoPesquisadorPivot_Pesquisador_PesquisadorId",
                        column: x => x.PesquisadorId,
                        principalTable: "Pesquisador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoPesquisadorPivot_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Captacao_ProjetoId",
                table: "Captacao",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisador_SubareaId",
                table: "Pesquisador",
                column: "SubareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producao_ProjetoId",
                table: "Producao",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_SubareaId",
                table: "Projeto",
                column: "SubareaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoPesquisadorPivot_PesquisadorId",
                table: "ProjetoPesquisadorPivot",
                column: "PesquisadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoPesquisadorPivot_ProjetoId",
                table: "ProjetoPesquisadorPivot",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubareaConhecimento_AreaConhecimentoId",
                table: "SubareaConhecimento",
                column: "AreaConhecimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Captacao");

            migrationBuilder.DropTable(
                name: "Producao");

            migrationBuilder.DropTable(
                name: "ProjetoPesquisadorPivot");

            migrationBuilder.DropTable(
                name: "Pesquisador");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "SubareaConhecimento");

            migrationBuilder.DropTable(
                name: "AreaConhecimento");
        }
    }
}
