using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Models;

namespace LogiTrack.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private static List<Categoria> _categorias = new List<Categoria>();
        private static int _proximoId = 1;

        public CategoriaService()
        {
            // Dados de exemplo para teste
            if (_categorias.Count == 0)
            {
                InicializarDadosExemplo();
            }
        }

        public Task<IEnumerable<Categoria>> ObterTodasAsync()
        {
            return Task.FromResult(_categorias.AsEnumerable());
        }

        public Task<Categoria?> ObterPorIdAsync(int id)
        {
            var categoria = _categorias.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(categoria);
        }

        public Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            categoria.Id = _proximoId++;
            _categorias.Add(categoria);
            return Task.FromResult(categoria);
        }

        public Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            var categoriaExistente = _categorias.FirstOrDefault(c => c.Id == categoria.Id);
            if (categoriaExistente != null)
            {
                categoriaExistente.Nome = categoria.Nome;
                categoriaExistente.Descricao = categoria.Descricao;
                categoriaExistente.Ativa = categoria.Ativa;
                return Task.FromResult(categoriaExistente);
            }
            throw new ArgumentException("Categoria não encontrada");
        }

        public Task<bool> ExcluirAsync(int id)
        {
            var categoria = _categorias.FirstOrDefault(c => c.Id == id);
            if (categoria != null)
            {
                _categorias.Remove(categoria);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<IEnumerable<Categoria>> ObterAtivasAsync()
        {
            var categoriasAtivas = _categorias.Where(c => c.Ativa);
            return Task.FromResult(categoriasAtivas);
        }

        private void InicializarDadosExemplo()
        {
            var categorias = new List<Categoria>
            {
                new Categoria { Id = _proximoId++, Nome = "Eletrônicos", Descricao = "Produtos eletrônicos e informática", Ativa = true },
                new Categoria { Id = _proximoId++, Nome = "Papelaria", Descricao = "Materiais de escritório e papelaria", Ativa = true },
                new Categoria { Id = _proximoId++, Nome = "Casa e Jardim", Descricao = "Produtos para casa e jardim", Ativa = true },
                new Categoria { Id = _proximoId++, Nome = "Roupas", Descricao = "Vestuário em geral", Ativa = true }
            };

            _categorias.AddRange(categorias);
        }
    }
}
