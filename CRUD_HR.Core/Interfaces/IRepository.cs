using CRUD_HR.Core.Entities;
using System.Linq.Expressions;

namespace CRUD_HR.Core.Interfaces
{
    public interface IRepository
    {
        public Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        public Task<bool> UpdateAsync<T>(T entity) where T : BaseEntity;
        public Task<bool> DeleteAsync<T>(T entity) where T : BaseEntity;
        public Task<T> GetAsync<T>(int id) where T : BaseEntity;
        public Task<T> GetAsync<T>(Expression<Func<T, bool>> spec) where T : BaseEntity;
        public Task<List<T>> ListAsync<T>(Expression<Func<T, bool>> spec) where T : BaseEntity;
        public Task<List<T>> ListAsync<T>() where T : BaseEntity;
    }
}
