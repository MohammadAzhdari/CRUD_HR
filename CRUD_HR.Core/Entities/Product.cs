using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Core.Entities
{
    public class Product : BaseEntity
    {
        [NotNull]
        public string Name { get; set; }
        public int CodeNumber { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        [NotNull]
        public string ImagePath { get; set; }
    }
}
