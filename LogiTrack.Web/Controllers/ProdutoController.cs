using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LogiTrack.Core.Services;
using LogiTrack.Core.Models;
using LogiTrack.Web.Models;

namespace LogiTrack.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> Index(string? busca)
        {
            IEnumerable<Produto> produtos;

            if (!string.IsNullOrWhiteSpace(busca))
            {
                produtos = await _produtoService.BuscarPorNomeAsync(busca);
                ViewBag.Busca = busca;
            }
            else
            {
                produtos = await _produtoService.ObterTodosAsync();
            }

            var viewModels = produtos.Select(p => new ProdutoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                QuantidadeEstoque = p.QuantidadeEstoque,
                CategoriaId = p.CategoriaId,
                CategoriaNome = p.Categoria?.Nome,
                CodigoBarras = p.CodigoBarras,
                DataCadastro = p.DataCadastro,
                DataUltimaAtualizacao = p.DataUltimaAtualizacao,
                Ativo = p.Ativo
            });

            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.Categoria?.Nome,
                CodigoBarras = produto.CodigoBarras,
                DataCadastro = produto.DataCadastro,
                DataUltimaAtualizacao = produto.DataUltimaAtualizacao,
                Ativo = produto.Ativo
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            await CarregarCategorias();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto
                {
                    Nome = viewModel.Nome,
                    Descricao = viewModel.Descricao,
                    Preco = viewModel.Preco,
                    QuantidadeEstoque = viewModel.QuantidadeEstoque,
                    CategoriaId = viewModel.CategoriaId,
                    CodigoBarras = viewModel.CodigoBarras,
                    Ativo = true
                };

                try
                {
                    await _produtoService.AdicionarAsync(produto);
                    TempData["Sucesso"] = "Produto criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao criar produto: {ex.Message}");
                }
            }

            await CarregarCategorias();
            return View(viewModel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CategoriaId = produto.CategoriaId,
                CodigoBarras = produto.CodigoBarras,
                Ativo = produto.Ativo
            };

            await CarregarCategorias();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produto = await _produtoService.ObterPorIdAsync(id);
                    if (produto == null)
                    {
                        return NotFound();
                    }

                    produto.Nome = viewModel.Nome;
                    produto.Descricao = viewModel.Descricao;
                    produto.Preco = viewModel.Preco;
                    produto.QuantidadeEstoque = viewModel.QuantidadeEstoque;
                    produto.CategoriaId = viewModel.CategoriaId;
                    produto.CodigoBarras = viewModel.CodigoBarras;

                    await _produtoService.AtualizarAsync(produto);
                    TempData["Sucesso"] = "Produto atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar produto: {ex.Message}");
                }
            }

            await CarregarCategorias();
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CategoriaNome = produto.Categoria?.Nome,
                CodigoBarras = produto.CodigoBarras,
                DataCadastro = produto.DataCadastro,
                DataUltimaAtualizacao = produto.DataUltimaAtualizacao
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var sucesso = await _produtoService.ExcluirAsync(id);
                if (sucesso)
                {
                    TempData["Sucesso"] = "Produto excluído com sucesso!";
                }
                else
                {
                    TempData["Erro"] = "Não foi possível excluir o produto.";
                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = $"Erro ao excluir produto: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task CarregarCategorias()
        {
            var categorias = await _categoriaService.ObterAtivasAsync();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
        }
    }
}