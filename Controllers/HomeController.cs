using Dimensiona.Models;
using Dimensiona.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimensiona.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDimensionamentoRepositorio _dimensionamentoRepositorio;
        public HomeController(IDimensionamentoRepositorio dimensionamentoRepositorio)
        {
            _dimensionamentoRepositorio = dimensionamentoRepositorio;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Inicio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar_dimensionamento(DimensionamentoModel dimensionamento)
        {
            _dimensionamentoRepositorio.Adicionar(dimensionamento);
            return RedirectToAction("", "Home");
        }
    }
}
