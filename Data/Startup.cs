using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Startup
    {

        public static IServiceCollection AddRepositories<TDbContext>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where TDbContext : DbContext
        {
            services.AddScoped<CidadeRepository>();
            services.AddScoped<EstadoRepository>();
            services.AddScoped<ClienteRepository>();
            //services.Add(new ServiceDescriptor(
            //    typeof(IRepository),
            //    serviceProvider =>
            //    {
            //        var dbContext = ActivatorUtilities.CreateInstance<TDbContext>(serviceProvider);
            //        return new Repository(dbContext);
            //    },
            //    serviceLifetime));

            //services.Add(new ServiceDescriptor(
            //    typeof(IUnitOfWork),
            //    serviceProvider =>
            //    {
            //        var repository = serviceProvider.GetService<IRepository>();
            //        return new UnitOfWork(repository);
            //    },
            //    serviceLifetime));
            return services;
        }
    }
}
