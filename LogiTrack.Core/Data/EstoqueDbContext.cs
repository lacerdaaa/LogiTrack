using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Data
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<MovimentoEstoque> MovimentosEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Descricao)
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Descricao)
                    .HasMaxLength(500);
                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();
                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(50);
                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.DataUltimaAtualizacao)
                    .HasColumnType("datetime");

                entity.HasOne(p => p.Categoria)
                    .WithMany(c => c.Produtos)
                    .HasForeignKey(p => p.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Nome);
                entity.HasIndex(e => e.CodigoBarras).IsUnique();
            });

            modelBuilder.Entity<MovimentoEstoque>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Observacao)
                    .HasMaxLength(200);
                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DataMovimento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.PrecoUnitario)
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(m => m.Produto)
                    .WithMany()
                    .HasForeignKey(m => m.ProdutoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.ProdutoId, e.DataMovimento });
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Eletrônicos", Descricao = "Produtos eletrônicos e informática", Ativa = true },
                new Categoria { Id = 2, Nome = "Papelaria", Descricao = "Materiais de escritório e papelaria", Ativa = true },
                new Categoria { Id = 3, Nome = "Casa e Jardim", Descricao = "Produtos para casa e jardim", Ativa = true },
                new Categoria { Id = 4, Nome = "Roupas", Descricao = "Vestuário em geral", Ativa = true }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Notebook Dell Inspiron",
                    Descricao = "Notebook Dell Inspiron 15 - Intel i5, 8GB RAM, 256GB SSD",
                    Preco = 2500.00m,
                    QuantidadeEstoque = 5,
                    CategoriaId = 1,
                    CodigoBarras = "7891234567890",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Mouse Logitech MX",
                    Descricao = "Mouse sem fio Logitech MX Master 3",
                    Preco = 299.90m,
                    QuantidadeEstoque = 15,
                    CategoriaId = 1,
                    CodigoBarras = "7891234567891",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Teclado Mecânico Gamer",
                    Descricao = "Teclado mecânico RGB com switches Cherry MX",
                    Preco = 450.00m,
                    QuantidadeEstoque = 8,
                    CategoriaId = 1,
                    CodigoBarras = "7891234567892",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                },
                new Produto
                {
                    Id = 4,
                    Nome = "Caneta BIC Cristal",
                    Descricao = "Caneta esferográfica azul BIC Cristal",
                    Preco = 1.50m,
                    QuantidadeEstoque = 200,
                    CategoriaId = 2,
                    CodigoBarras = "7891234567893",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                },
                new Produto
                {
                    Id = 5,
                    Nome = "Caderno Universitário",
                    Descricao = "Caderno universitário 200 folhas",
                    Preco = 15.90m,
                    QuantidadeEstoque = 50,
                    CategoriaId = 2,
                    CodigoBarras = "7891234567894",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                }
            );
        }
    }
}
