using Domain.Entities;
using Infrastructure.DbContexts;
using Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly Upd8DbContext _context;
        public ClienteRepository(Upd8DbContext context) : base(context)
        {
            _context = context;
        }

        public ResponsePageSize ListPageAsync(int pageNumber, int pageSize)
        {
            var retorno = new ResponsePageSize(null, 0);
            
            var clientes = _context.Set<Cliente>();
                
             retorno.Total = clientes.Count();
            retorno.Clientes = clientes.OrderBy(x => x.Nome).Skip(pageNumber * pageSize).Take(pageSize);

            return retorno;
        }

        public int CountClientes()
        {
            return _context.Set<Cliente>().Count();
        }
        
    }
}
