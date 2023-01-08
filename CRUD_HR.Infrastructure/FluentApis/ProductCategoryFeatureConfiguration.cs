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
    public class ProductCategoryFeatureConfiguration : IEntityTypeConfiguration<ProductCategoryFeature>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryFeature> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.ProductCategoryFeatureType)
                .WithMany(x => x.ProductCategoryFeatures)
                .HasForeignKey(x => x.TypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.ProductCategoryFeatures)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
