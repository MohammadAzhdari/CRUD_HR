using CRUD_HR.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CRUD_HR.Core.Interfaces;

namespace CRUD_HR.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _db;

        public EfRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _db.Set<T>().Entry(entity).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _db.Set<T>().Remove(entity);
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }

        public async Task<T> GetAsync<T>(int id) 
            where T : BaseEntity =>
            await _db.Set<T>().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> spec) 
            where T : BaseEntity =>
            await _db.Set<T>().SingleOrDefaultAsync(spec);

        public async Task<List<T>> ListAsync<T>(Expression<Func<T, bool>> spec) 
            where T : BaseEntity =>
            await _db.Set<T>().Where(spec).ToListAsync();
    }
}
