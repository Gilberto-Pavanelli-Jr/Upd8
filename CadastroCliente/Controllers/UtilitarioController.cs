using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;

namespace CadastroCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitarioController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly CidadeRepository _cidadeRepossitory;

        private readonly EstadoRepository _estadoRepossitory;
        public UtilitarioController(IUnitOfWork unitOfWork, CidadeRepository cidadeRepossitory, EstadoRepository estadoRepossitory)
        {
            _unitOfWork = unitOfWork;
            _cidadeRepossitory = cidadeRepossitory;
            _estadoRepossitory = estadoRepossitory;
        }

        [HttpGet("GetEstados")]
        public async Task<IActionResult> GetEstados()
        {

            var lista = await _estadoRepossitory.ListAsync().ToListAsync();
            return Ok(lista);
        }

        [HttpGet("GetCidadesPorEstado")]
        public async Task<IActionResult> GetCidadesPorEstadoAsync(string NomeEstado)
        {
            try
            {
                var lista = await _cidadeRepossitory.GetCidadesPorEstadoAsync(NomeEstado);
                return Ok(lista);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
            
        }
    }
}
