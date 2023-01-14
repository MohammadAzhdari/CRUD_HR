using CRUD_HR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Utility
{
    public class EfRepositoryConditions
    {
        public static Expression<Func<Product, bool>> GetProductList()
        {
            Expression<Func<Product, bool>> func = x => x.IsActive;
            return func;
        }
    }
}
