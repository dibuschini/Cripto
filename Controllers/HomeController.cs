using Dimensiona.Models;
using Dimensiona.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace Dimensiona.Controllers
{
    public class HomeController : Controller
    {


        private static readonly HttpClient client = new HttpClient();
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
        public async Task<RedirectToActionResult> Criar_ordem(Trade trade)
        {
            var payload = new
            {
                side = "BUY",
                quantity = trade.Quantidade,
                symbol = trade.Moeda,
                options = new { type = "MARKET" }
            };

            var serializedPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(serializedPayload, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://cmpg36unveiqlwo2oxun46anvu0pugzu.lambda-url.sa-east-1.on.aws/buy", content);

            var responseString = await response.Content.ReadAsStringAsync();
            return RedirectToAction("index", "Home");
        }
    }
    }



   
