﻿// <auto-generated />
using System;
using System.Collections.Generic;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsightHub.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InsightHub.Models.AreaConhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AreaConhecimento");
                });

            modelBuilder.Entity("InsightHub.Models.Captacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("integer");

                    b.Property<double?>("Valor")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Captacao");
                });

            modelBuilder.Entity("InsightHub.Models.Pesquisador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("SubareaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubareaId");

                    b.ToTable("Pesquisador");
                });

            modelBuilder.Entity("InsightHub.Models.Producao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Producao");
                });

            modelBuilder.Entity("InsightHub.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("DescricaoCurta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("Pesquisadores")
                        .HasColumnType("integer[]");

                    b.Property<int>("SubareaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubareaId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("InsightHub.Models.ProjetoPesquisadorPivot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PesquisadorId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PesquisadorId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ProjetoPesquisadorPivot");
                });

            modelBuilder.Entity("InsightHub.Models.SubareaConhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaConhecimentoId")
                        .HasColumnType("integer");

                    b.Property<int>("AreaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AreaConhecimentoId");

                    b.ToTable("SubareaConhecimento");
                });

            modelBuilder.Entity("InsightHub.Models.Captacao", b =>
                {
                    b.HasOne("InsightHub.Models.Projeto", "Proj")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proj");
                });

            modelBuilder.Entity("InsightHub.Models.Pesquisador", b =>
                {
                    b.HasOne("InsightHub.Models.SubareaConhecimento", "Subarea")
                        .WithMany()
                        .HasForeignKey("SubareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subarea");
                });

            modelBuilder.Entity("InsightHub.Models.Producao", b =>
                {
                    b.HasOne("InsightHub.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("InsightHub.Models.Projeto", b =>
                {
                    b.HasOne("InsightHub.Models.SubareaConhecimento", "Subarea")
                        .WithMany()
                        .HasForeignKey("SubareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subarea");
                });

            modelBuilder.Entity("InsightHub.Models.ProjetoPesquisadorPivot", b =>
                {
                    b.HasOne("InsightHub.Models.Pesquisador", "Pesquisador")
                        .WithMany()
                        .HasForeignKey("PesquisadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHub.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pesquisador");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("InsightHub.Models.SubareaConhecimento", b =>
                {
                    b.HasOne("InsightHub.Models.AreaConhecimento", "AreaConhecimento")
                        .WithMany()
                        .HasForeignKey("AreaConhecimentoId");

                    b.Navigation("AreaConhecimento");
                });
#pragma warning restore 612, 618
        }
    }
}
