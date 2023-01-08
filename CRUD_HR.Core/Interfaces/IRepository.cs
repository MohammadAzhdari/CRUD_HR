using System.Linq.Expressions;

namespace CRUD_HR.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
        public Task<T> GetAsync(int id);
        public Task<T> GetAsync(Expression<Func<T, bool>> spec);
        public Task<List<T>> ListAsync(Expression<Func<T, bool>> spec);

    }
}
