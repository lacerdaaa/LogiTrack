using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiTrack.Core.Data;
using LogiTrack.Core.Models;
using LogiTrack.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly EstoqueDbContext _context;

        public CategoriaService(EstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObterTodasAsync()
        {
            return await _context.Categorias
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }

        public async Task<Categoria?> ObterPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(categoria.Id);
            if (categoriaExistente == null)
                throw new ArgumentException("Categoria não encontrada");

            categoriaExistente.Nome = categoria.Nome;
            categoriaExistente.Descricao = categoria.Descricao;
            categoriaExistente.Ativa = categoria.Ativa;

            await _context.SaveChangesAsync();
            return categoriaExistente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return false;

            var temProdutos = await _context.Produtos
                .AnyAsync(p => p.CategoriaId == id && p.Ativo);

            if (temProdutos)
            {
                categoria.Ativa = false;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<IEnumerable<Categoria>> ObterAtivasAsync()
        {
            return await _context.Categorias
                .Where(c => c.Ativa)
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }
    }
}
