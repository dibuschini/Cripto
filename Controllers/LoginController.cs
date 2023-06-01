using Dimensiona.Data;
using Dimensiona.Models;
using Dimensiona.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Dimensiona.Controllers
{
    public class LoginController : Controller
    {

        private readonly BancoContext _dbContext;

        public LoginController(BancoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("inicio","Home");
            return View();
        }

        public IActionResult Criar_usuario()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public async Task<IActionResult> ValidarLogin(UsuarioModel model)
        {
            // Use Entity Framework to retrieve the user from the database.
            var user = _dbContext.Usuario.SingleOrDefault(u => u.Email == model.Email);

            // Compare the username and password from the login request to the username and password of the user in the database.
            if (user != null && user.Senha == model.Senha)
            {
                // Redirect the user to the home page.
                
                await new Services().Login(HttpContext, model);
                return RedirectToAction("inicio","Home");
            }
            else
            {
                // Display an error message to the user.
                TempData["AlertMessage"] = "Usuário ou senha invalidos.";
                return RedirectToAction("index", "Login");
            }
        }

        [Authorize]
        public async Task<IActionResult> Sair()
        {
            await new Services().Logoff(HttpContext);
            return RedirectToAction("index","Login");
        }
    }
}