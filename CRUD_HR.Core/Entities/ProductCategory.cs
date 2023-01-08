using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Entities
{
    public class ProductCategory : BaseEntity
    {
        [NotNull]
        public string Name { get; set; }
        public ICollection<ProductCategoryFeature> ProductCategoryFeatures { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
