using CRUD_HR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Interfaces
{
    public interface IProductCategoryFeatureValueRepository
    {
        public Task<ProductCategoryFeatureValue> GetAsync(int id);
        public Task<List<ProductCategoryFeatureValue>> ListAsync();
    }
}
