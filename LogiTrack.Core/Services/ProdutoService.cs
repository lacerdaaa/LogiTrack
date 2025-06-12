using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Models;

namespace LogiTrack.Core.Services
{
    public class ProdutoService : IProdutoService
    {
        private static List<Produto> _produtos = new List<Produto>();
        private static int _proximoId = 1;

        public ProdutoService()
        {
            // Dados de exemplo para teste
            if (_produtos.Count == 0)
            {
                InicializarDadosExemplo();
            }
        }

        public Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return Task.FromResult(_produtos.AsEnumerable());
        }

        public Task<Produto?> ObterPorIdAsync(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(produto);
        }

        public Task<Produto> AdicionarAsync(Produto produto)
        {
            produto.Id = _proximoId++;
            produto.DataCadastro = DateTime.Now;
            _produtos.Add(produto);
            return Task.FromResult(produto);
        }

        public Task<Produto> AtualizarAsync(Produto produto)
        {
            var produtoExistente = _produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoExistente != null)
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Preco = produto.Preco;
                produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
                produtoExistente.CategoriaId = produto.CategoriaId;
                produtoExistente.CodigoBarras = produto.CodigoBarras;
                produtoExistente.Ativo = produto.Ativo;
                produtoExistente.DataUltimaAtualizacao = DateTime.Now;
                return Task.FromResult(produtoExistente);
            }
            throw new ArgumentException("Produto não encontrado");
        }

        public Task<bool> ExcluirAsync(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome)
        {
            var produtos = _produtos.Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(produtos);
        }

        public Task<IEnumerable<Produto>> ObterPorCategoriaAsync(int categoriaId)
        {
            var produtos = _produtos.Where(p => p.CategoriaId == categoriaId);
            return Task.FromResult(produtos);
        }

        public Task<IEnumerable<Produto>> ObterEstoqueBaixoAsync()
        {
            var produtos = _produtos.Where(p => p.EstoqueBaixo && p.Ativo);
            return Task.FromResult(produtos);
        }

        public Task<bool> AtualizarEstoqueAsync(int produtoId, int novaQuantidade)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto != null)
            {
                produto.QuantidadeEstoque = novaQuantidade;
                produto.DataUltimaAtualizacao = DateTime.Now;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        private void InicializarDadosExemplo()
        {
            var produtos = new List<Produto>
            {
                new Produto { Id = _proximoId++, Nome = "Notebook Dell", Descricao = "Notebook Dell Inspiron 15", Preco = 2500.00m, QuantidadeEstoque = 5, CategoriaId = 1, CodigoBarras = "123456789" },
                new Produto { Id = _proximoId++, Nome = "Mouse Logitech", Descricao = "Mouse sem fio", Preco = 89.90m, QuantidadeEstoque = 25, CategoriaId = 1, CodigoBarras = "987654321" },
                new Produto { Id = _proximoId++, Nome = "Teclado Mecânico", Descricao = "Teclado mecânico RGB", Preco = 299.99m, QuantidadeEstoque = 8, CategoriaId = 1, CodigoBarras = "456789123" },
                new Produto { Id = _proximoId++, Nome = "Caneta Bic", Descricao = "Caneta esferográfica azul", Preco = 1.50m, QuantidadeEstoque = 100, CategoriaId = 2, CodigoBarras = "789123456" },
                new Produto { Id = _proximoId++, Nome = "Caderno 200 folhas", Descricao = "Caderno universitário", Preco = 15.90m, QuantidadeEstoque = 30, CategoriaId = 2, CodigoBarras = "321654987" }
            };

            _produtos.AddRange(produtos);
        }
    }
}
