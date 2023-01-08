using CRUD_HR.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_HR.Infrastructure.FluentApis
{
    public class ProductCategoryFeatureTypeConfiguration : IEntityTypeConfiguration<ProductCategoryFeatureType>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryFeatureType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
