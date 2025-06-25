using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Models;

namespace LogiTrack.Core.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObterTodasAsync();
        Task<Categoria?> ObterPorIdAsync(int id);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<Categoria>> ObterAtivasAsync();
    }
}
