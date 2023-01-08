using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Entities
{
    public class ProductCategoryFeatureValue : BaseEntity
    {
        public string value { get; set; }
        public int FeatureId { get; set; }
        public ProductCategoryFeature ProductCategoryFeature { get; set; }
    }
}
