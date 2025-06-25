using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Services.Interfaces;

namespace LogiTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public HomeController(IProdutoService produtoService, ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalProdutos = (await _produtoService.ObterTodosAsync()).Count();
            ViewBag.TotalCategorias = (await _categoriaService.ObterTodasAsync()).Count();
            ViewBag.ProdutosEstoqueBaixo = (await _produtoService.ObterEstoqueBaixoAsync()).Count();

            var produtosRecentes = (await _produtoService.ObterTodosAsync())
                .OrderByDescending(p => p.DataCadastro)
                .Take(5);

            return View(produtosRecentes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}