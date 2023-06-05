using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.CatalogModule.Configurations
{
    public class ProductTypeTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(x => x.Id);

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType { Id = 1, Name = "AMBER" },
                new ProductType { Id = 2, Name = "DARK" },
                 new ProductType { Id = 3, Name = "CLEAR" }
                );
        }
    }
}
