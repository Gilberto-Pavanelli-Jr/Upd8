using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    public class ResponsePageSize
    {
       public IQueryable<Cliente>? Clientes { get; set; }

        public ResponsePageSize(IQueryable<Cliente>? clientes, int total)
        {
            Clientes = clientes;
            Total = total;
        }

        public int Total { get; set; }
    }
}
