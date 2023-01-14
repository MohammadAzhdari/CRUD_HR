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
    public class ProductCategoryFeatureRepository : IProductCategoryFeatureRepository
    {
        private readonly AppDbContext _db;

        public ProductCategoryFeatureRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<ProductCategoryFeature> GetAsync(int id)
        => await _db.ProductCategoryFeature
            .Include("ProductCategory")
            .Include("ProductCategoryFeatureType")
            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<ProductCategoryFeature>> ListAsync()
        => await _db.ProductCategoryFeature
            .Include("ProductCategory")
            .Include("ProductCategoryFeatureType")
            .OrderByDescending(x => x.Id)
            .ToListAsync();
    }
}
