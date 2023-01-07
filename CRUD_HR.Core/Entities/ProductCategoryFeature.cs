using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Entities
{
    public class ProductCategoryFeature : BaseEntity
    {
        [NotNull]
        public string Name { get; set; }
        public ICollection<ProductCategoryFeatureValue> ProductCategoryFeatureValues { get; set; }
        public ProductCategoryFeatureEnumType ProductCategoryFeatureEnumType { get; set; }
    }
}
