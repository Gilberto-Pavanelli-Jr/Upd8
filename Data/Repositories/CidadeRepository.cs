using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CidadeRepository : IRepository<Cidade>
    {
        protected readonly Upd8DbContext _context;

        public CidadeRepository(Upd8DbContext context) : base(context)
        {
            _context= context;
        }


        //public CidadeRepository(Upd8DbContext context)
        //{
        //    _context = context;
        //}

        public Task<Cidade> AddItemAsync(Cidade item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cidade>> GetCidades()
        {
            return await _context.Cidades.Include("Estado").ToListAsync();
        }

        public async Task<ICollection<Cidade>> GetCidadesPorEstadoAsync(string NomeEstado)
        {
            return await _context.Cidades.Where(x=>x.Estado.NomeEstado == NomeEstado).OrderBy(x=>x.NomeCidade).ToListAsync();
        }

        public IQueryable<Cidade> ListAsync()
        {
            throw new NotImplementedException();
        }

      

    }
}
