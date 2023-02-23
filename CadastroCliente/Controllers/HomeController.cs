using CadastroCliente.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CadastroCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EstadoRepository _estadoRepository;
        private readonly ClienteRepository _clienteRepository;

        public HomeController(ILogger<HomeController> logger, EstadoRepository estadoRepository = null, ClienteRepository clienteRepository = null)
        {
            _logger = logger;
            _estadoRepository = estadoRepository;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/Cadastrar")]
        [Route("/Cadastrar/{id}")]
        [Route("/Cadastrar/Apagar/{id}")]
        public async Task<IActionResult> Cadastrar(Guid? id)
        {
            ViewBag.Estados = await _estadoRepository.ListAsync().ToListAsync();
            if (id != null)
            {
                ViewBag.Cliente = await _clienteRepository.FindByIdAsync((Guid)id);
            }

            return View();
        }
        public IActionResult Consultar()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}