using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        [NotNull]
        public string Path { get; set; }
        public bool IsBanner { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
