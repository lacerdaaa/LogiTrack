using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Models;

namespace LogiTrack.Core.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterTodosAsync();
        Task<Produto?> ObterPorIdAsync(int id);
        Task<Produto> AdicionarAsync(Produto produto);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome);
        Task<IEnumerable<Produto>> ObterPorCategoriaAsync(int categoriaId);
        Task<IEnumerable<Produto>> ObterEstoqueBaixoAsync();
        Task<bool> AtualizarEstoqueAsync(int produtoId, int novaQuantidade);
    }
}
