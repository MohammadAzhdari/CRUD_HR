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
    public class ProductCategoryFeatureValueRepository : IProductCategoryFeatureValueRepository
    {
        private readonly AppDbContext _db;

        public ProductCategoryFeatureValueRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<ProductCategoryFeatureValue> GetAsync(int id)
        => await _db.ProductCategoryFeatureValue
            .Include("ProductCategoryFeature")
            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<ProductCategoryFeatureValue>> ListAsync()
        => await _db.ProductCategoryFeatureValue
            .Include("ProductCategoryFeature")
            .OrderByDescending(x => x.Id)
            .ToListAsync();
    }
}
