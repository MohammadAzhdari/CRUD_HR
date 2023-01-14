using CRUD_HR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> ListAsync();
    }
}
