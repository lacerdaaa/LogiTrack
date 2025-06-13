using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Data;
using LogiTrack.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly EstoqueDbContext _context;

        public ProdutoService(EstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Ativo)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produto> AdicionarAsync(Produto produto)
        {
            produto.DataCadastro = DateTime.Now;
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return await ObterPorIdAsync(produto.Id) ?? produto;
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(produto.Id);
            if (produtoExistente == null)
                throw new ArgumentException("Produto não encontrado");

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoExistente.CategoriaId = produto.CategoriaId;
            produtoExistente.CodigoBarras = produto.CodigoBarras;
            produtoExistente.Ativo = produto.Ativo;
            produtoExistente.DataUltimaAtualizacao = DateTime.Now;

            await _context.SaveChangesAsync();

            return await ObterPorIdAsync(produto.Id) ?? produtoExistente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return false;

            produto.Ativo = false;
            produto.DataUltimaAtualizacao = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Nome.Contains(nome) && p.Ativo)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoriaAsync(int categoriaId)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoriaId && p.Ativo)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterEstoqueBaixoAsync()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.QuantidadeEstoque <= 10 && p.Ativo)
                .OrderBy(p => p.QuantidadeEstoque)
                .ToListAsync();
        }

        public async Task<bool> AtualizarEstoqueAsync(int produtoId, int novaQuantidade)
        {
            var produto = await _context.Produtos.FindAsync(produtoId);
            if (produto == null)
                return false;

            produto.QuantidadeEstoque = novaQuantidade;
            produto.DataUltimaAtualizacao = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
