using Infrastructure.DbContexts;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarCliente([FromBody] Cliente dto)
        {
            try
            {
                await _clienteRepository.AddItemAsync(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpGet("ListClientes")]
        public async Task<IActionResult> ListClientes()
        {
            try
            {
                var clientes = await _clienteRepository.ListAsync().ToListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPost("ListClientesFiltrado")]
        public IActionResult ListClientesFiltrado(Cliente cliente, [FromQuery] int pageNumber, int pageSize)
        {
            try
            {
                ResponsePageSize retorno = new ResponsePageSize(null, 0);
                var clientes = _clienteRepository.ListAsync();

                if (!string.IsNullOrEmpty(cliente.Nome))
                {
                    clientes = clientes.Where(x => x.Nome.Contains(cliente.Nome));
                }
                if (!string.IsNullOrEmpty(cliente.Estado))
                {
                    clientes = clientes.Where(x => x.Estado.Equals(cliente.Estado));
                }
                if (!string.IsNullOrEmpty(cliente.Cidade))
                {
                    clientes = clientes.Where(x => x.Cidade.Equals(cliente.Cidade));
                }
                if (!string.IsNullOrEmpty(cliente.Endereco))
                {
                    clientes = clientes.Where(x => x.Endereco.Contains(cliente.Endereco));
                }
                if (!string.IsNullOrEmpty(cliente.Sexo))
                {
                    clientes = clientes.Where(x => x.Sexo == cliente.Sexo);
                }
                if (!string.IsNullOrEmpty(cliente.Cpf))
                {
                    clientes = clientes.Where(x => x.Cpf == cliente.Cpf);
                }
                retorno.Total = clientes.Count();
                retorno.Clientes =  clientes.OrderBy(x => x.Nome).Skip(pageNumber * pageSize).Take(pageSize);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpGet("CountClientes")]
        public IActionResult CountClientes()
        {
            try
            {
                var count = _clienteRepository.CountClientes();

                return Ok(count);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpGet("ListClientesPage")]
        public IActionResult ListClientesPage([FromQuery] int pageNumber, int pageSize)
        {
            try
            {
                ResponsePageSize retorno = new ResponsePageSize(null, 0);
                retorno =  _clienteRepository.ListPageAsync(pageNumber, pageSize);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpGet("GetClienteById")]
        [Route("GetClienteById/{id}")]
        public async Task<IActionResult> GetClienteById(Guid id)
        {
            try
            {
                var cliente = await _clienteRepository.FindByIdAsync(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPut("UpdateCliente")]
        [Route("UpdateCliente/{id}")]
        public IActionResult UpdateCliente(Cliente cliente)
        {
            try
            {
                _clienteRepository.UpdateItem(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpDelete("ApagarCliente")]
        [Route("ApagarCliente/{id}")]
        public IActionResult ApagarCliente(Cliente cliente)
        {
            try
            {
                _clienteRepository.RemoveItem(cliente);
                return Ok(true);
            }
            catch (Exception ex)
            {
                // log erro
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
    }
}
