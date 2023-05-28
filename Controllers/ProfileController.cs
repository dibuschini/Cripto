using Microsoft.AspNetCore.Mvc;
using Dimensiona.Models;
using Dimensiona.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace Dimensiona.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public ProfileController(IUsuarioRepositorio usuarioRepositorio)
        {
           _usuarioRepositorio = usuarioRepositorio;
        }
        [Authorize]
        public IActionResult Profile()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);

        }

        [HttpPost]
        public IActionResult Criar_usuario(UsuarioModel usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {
            _usuarioRepositorio?.Editar(usuario);
            TempData["AlertMessage"] = "Usuário atualizado com sucesso.";
            return RedirectToAction("profile", "Profile");
        }
    }
}
