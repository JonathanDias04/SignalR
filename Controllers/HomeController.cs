using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalR.Hubs;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PollHub _pollHub;

        public HomeController(ILogger<HomeController> logger, PollHub pollHub)
        {
            _logger = logger;
            _pollHub = pollHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task CadastrarPaciente()
        {
            await _pollHub.SendMessage("Iniciando Cadastramento de Pacientes");
            Thread.Sleep(3000);

            List<string> pacientes = new List<string>();

            pacientes.Add("João");
            await _pollHub.SendMessage("O paciente João foi cadastrado com sucesso");
            Thread.Sleep(3000);

            pacientes.Add("Flávio");
            await _pollHub.SendMessage("O paciente Flávio foi cadastrado com sucesso");
            Thread.Sleep(3000);

            pacientes.Add("Maria");
            await _pollHub.SendMessage("A paciente Maria foi cadastrada com sucesso");
            Thread.Sleep(3000);

            await _pollHub.SendMessage("Todos os pacientes foram cadastrados com sucesso");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
