using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> FindByIdAsync(Guid id);

        public IQueryable<T> ListAsync(Expression<Func<T, bool>> clause);
        //public IQueryable<T> ListAsync<T>(Expression<Func<T, bool>> clause, params Expression<Func<T, object>>[] includeProperties) where T : class;
        public List<T> ListAsync();
        public Task<T> AddItemAsync(T item);
        public bool RemoveItem(T item);
        public bool UpdateItem(T item);


    }
}
