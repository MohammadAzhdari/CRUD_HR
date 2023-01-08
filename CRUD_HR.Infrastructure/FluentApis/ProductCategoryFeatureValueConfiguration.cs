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
    public class ProductCategoryFeatureValueConfiguration : IEntityTypeConfiguration<ProductCategoryFeatureValue>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryFeatureValue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.value).IsRequired();
            builder.HasOne(x => x.ProductCategoryFeature)
                .WithMany(x => x.ProductCategoryFeatureValues)
                .HasForeignKey(x => x.FeatureId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
