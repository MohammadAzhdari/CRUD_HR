using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Product> GetAsync(int id)
        => await _db.Product
            .Include("Category")
            .Include("Images")
            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Product>> ListAsync()
        => await _db.Product
            .Where(x => x.IsActive)
            .Include("Category")
            .Include("Images")
            .OrderByDescending(x => x.Id)
            .ToListAsync();
    }
}
