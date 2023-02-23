using Infrastructure.DbContexts;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class IRepository<T> : IDisposable, Domain.Interfaces.IRepository<T> where T : class
    {
        protected readonly Upd8DbContext _context;

        public IRepository(Upd8DbContext context)
        {
            _context = context;
        }
        public virtual async Task<T?> FindByIdAsync(Guid id)
        {
            try
            {
                var item = await _context.Set<T>().FindAsync(id);
                return item;
            }
            catch (Exception)
            {
                // log exception
            }
            return null;
        }

        public virtual bool RemoveItem(T item)
        {
            try
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // log exception
            }
            return false;
        }
        public virtual IQueryable<T> ListAsync(Expression<Func<T, bool>> whereClause)
        {
            try
            {
                var items = _context.Set<T>().Where(whereClause);
                return items;
            }
            catch (Exception)
            {
                // log exception
            }
            return Enumerable.Empty<T>().AsQueryable();
        }

        //    public virtual IQueryable<T> ListAsync<T>(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includeProperties) where T : class
        //    {
        //        try
        //        {
        //            var items = _context.Set<T>().Include(includeProperties[0]).Where(whereClause);
        //            //foreach (Expression<Func<T, object>> includeProperty in includeProperties)
        //            //{
        //            //    items = items.Include<T, object>(includeProperty);
        //            //}
        //            return items;
        //        }
        //        catch (Exception ex)
        //        {
        //            // log exception
        //        }
        //        return Enumerable.Empty<T>().AsQueryable();
        //    }
        public void Dispose() => _context.Dispose();

        public IQueryable<T> ListAsync()
        {
            return _context.Set<T>();
        }


        public async Task<T> AddItemAsync(T item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        List<T> Domain.Interfaces.IRepository<T>.ListAsync()
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(T item)
        {

            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // log exception
            }
            return false;
        }

    }
}
