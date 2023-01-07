using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Entities
{
    public class ProductCategoryFeatureEnumType : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductCategoryFeature> ProductCategoryFeatures { get; set; }
    }

    public enum ProductCategoryFeatureType
    {
        _string = 1,
        _int = 2,
        _bool = 3
    }
}
