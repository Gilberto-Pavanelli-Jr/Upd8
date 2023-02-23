using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class EstadoRepository : IRepository<Estado>
    {

        protected readonly Upd8DbContext _context;

        public EstadoRepository(Upd8DbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Estado> List()
        {
            return _context.Estados.OrderByDescending(x => x.NomeEstado);
        }
    }
}
