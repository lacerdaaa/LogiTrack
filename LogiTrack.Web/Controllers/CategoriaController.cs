using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Services;
using LogiTrack.Core.Models;
using LogiTrack.Web.Models;

namespace LogiTrack.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObterTodasAsync();
            var viewModels = categorias.Select(c => new CategoriaViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao,
                Ativa = c.Ativa,
                QuantidadeProdutos = c.Produtos?.Count ?? 0
            });

            return View(viewModels);
        }
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            var viewModel = new CategoriaViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                Ativa = categoria.Ativa,
                QuantidadeProdutos = categoria.Produtos?.Count ?? 0
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria
                {
                    Nome = viewModel.Nome,
                    Descricao = viewModel.Descricao,
                    Ativa = true
                };

                try
                {
                    await _categoriaService.AdicionarAsync(categoria);
                    TempData["Sucesso"] = "Categoria criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao criar categoria: {ex.Message}");
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            var viewModel = new CategoriaViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                Ativa = categoria.Ativa
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var categoria = await _categoriaService.ObterPorIdAsync(id);
                    if (categoria == null)
                    {
                        return NotFound();
                    }

                    categoria.Nome = viewModel.Nome;
                    categoria.Descricao = viewModel.Descricao;
                    categoria.Ativa = viewModel.Ativa;

                    await _categoriaService.AtualizarAsync(categoria);
                    TempData["Sucesso"] = "Categoria atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar categoria: {ex.Message}");
                }
            }

            return View(viewModel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            var viewModel = new CategoriaViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                Ativa = categoria.Ativa,
                QuantidadeProdutos = categoria.Produtos?.Count ?? 0
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var sucesso = await _categoriaService.ExcluirAsync(id);
                if (sucesso)
                {
                    TempData["Sucesso"] = "Categoria excluída com sucesso!";
                }
                else
                {
                    TempData["Erro"] = "Não foi possível excluir a categoria.";
                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = $"Erro ao excluir categoria: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}