using CRUD_HR.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CRUD_HR.Core.Interfaces;

namespace CRUD_HR.Infrastructure.Data
{
    public class EfRepository<T> where T : BaseEntity, IRepository<T>
    {
        private readonly AppDbContext _db;

        public EfRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _db.Set<T>().Entry(entity).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }

        public async Task<T> GetAsync(int id) =>
            await _db.Set<T>().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> spec) =>
            await _db.Set<T>().SingleOrDefaultAsync(spec);

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> spec) =>
            await _db.Set<T>().Where(spec).ToListAsync();
    }
}
