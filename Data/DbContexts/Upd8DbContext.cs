using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace Infrastructure.DbContexts
{
    public class Upd8DbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public Upd8DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
    }
}


