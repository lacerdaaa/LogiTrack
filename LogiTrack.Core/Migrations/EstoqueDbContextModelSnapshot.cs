﻿// <auto-generated />
using System;
using LogiTrack.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogiTrack.Core.Migrations
{
    [DbContext(typeof(EstoqueDbContext))]
    partial class EstoqueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LogiTrack.Core.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativa")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativa = true,
                            Descricao = "Produtos eletrônicos e informática",
                            Nome = "Eletrônicos"
                        },
                        new
                        {
                            Id = 2,
                            Ativa = true,
                            Descricao = "Materiais de escritório e papelaria",
                            Nome = "Papelaria"
                        },
                        new
                        {
                            Id = 3,
                            Ativa = true,
                            Descricao = "Produtos para casa e jardim",
                            Nome = "Casa e Jardim"
                        },
                        new
                        {
                            Id = 4,
                            Ativa = true,
                            Descricao = "Vestuário em geral",
                            Nome = "Roupas"
                        });
                });

            modelBuilder.Entity("LogiTrack.Core.Models.MovimentoEstoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataMovimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal?>("PrecoUnitario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId", "DataMovimento");

                    b.ToTable("MovimentosEstoque");
                });

            modelBuilder.Entity("LogiTrack.Core.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoBarras")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CodigoBarras")
                        .IsUnique();

                    b.HasIndex("Nome");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            CategoriaId = 1,
                            CodigoBarras = "7891234567890",
                            DataCadastro = new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4021),
                            Descricao = "Notebook Dell Inspiron 15 - Intel i5, 8GB RAM, 256GB SSD",
                            Nome = "Notebook Dell Inspiron",
                            Preco = 2500.00m,
                            QuantidadeEstoque = 5
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            CategoriaId = 1,
                            CodigoBarras = "7891234567891",
                            DataCadastro = new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4026),
                            Descricao = "Mouse sem fio Logitech MX Master 3",
                            Nome = "Mouse Logitech MX",
                            Preco = 299.90m,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            CategoriaId = 1,
                            CodigoBarras = "7891234567892",
                            DataCadastro = new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4030),
                            Descricao = "Teclado mecânico RGB com switches Cherry MX",
                            Nome = "Teclado Mecânico Gamer",
                            Preco = 450.00m,
                            QuantidadeEstoque = 8
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            CategoriaId = 2,
                            CodigoBarras = "7891234567893",
                            DataCadastro = new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4034),
                            Descricao = "Caneta esferográfica azul BIC Cristal",
                            Nome = "Caneta BIC Cristal",
                            Preco = 1.50m,
                            QuantidadeEstoque = 200
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            CategoriaId = 2,
                            CodigoBarras = "7891234567894",
                            DataCadastro = new DateTime(2025, 6, 17, 20, 38, 18, 856, DateTimeKind.Local).AddTicks(4038),
                            Descricao = "Caderno universitário 200 folhas",
                            Nome = "Caderno Universitário",
                            Preco = 15.90m,
                            QuantidadeEstoque = 50
                        });
                });

            modelBuilder.Entity("LogiTrack.Core.Models.MovimentoEstoque", b =>
                {
                    b.HasOne("LogiTrack.Core.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LogiTrack.Core.Models.Produto", b =>
                {
                    b.HasOne("LogiTrack.Core.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("LogiTrack.Core.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
