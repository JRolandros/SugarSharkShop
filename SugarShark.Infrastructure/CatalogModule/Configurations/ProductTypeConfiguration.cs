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
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.ProductType)
                .WithMany(c=>c.Products)
                .HasForeignKey(x => x.ProductTypeId);

            SeedData(builder);
        }


        private void SeedData(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 11,
                    Name = "Cookies",
                    Image = "cookies-image-base64",
                    Price = 30,
                    Stock = 20,
                    Description = " Baby shark sugar cookies",
                    ProductTypeId=1
                },
                new Product
                {
                    Id = 12,
                    Name = "Cakesicles",
                    Image = "Cakesicles-image-base64",
                    Price = 30,
                    Stock = 20,
                    Description = " Baby shark sugar Cakesicles",
                    ProductTypeId = 1
                },
                new Product
                {
                    Id = 13,
                    Name = "Cookies",
                    Image = "cookies-image-base64",
                    Price = 50,
                    Stock = 10,
                    Description = " Baby shark sugar cookies",
                    ProductTypeId = 2
                },
                new Product
                {
                    Id = 14,
                    Name = "Cookies",
                    Image = "cookies-image-base64",
                    Price = 5,
                    Stock = 2,
                    Description = " Baby shark sugar cookies",
                    ProductTypeId = 3
                },
                new Product
                {
                    Id = 15,
                    Name = "Cupcake",
                    Image = "Cupcake-image-base64",
                    Price = 40,
                    Stock = 60,
                    Description = " shark sugar Cupcake",
                    ProductTypeId = 3
                },
                new Product
                {
                    Id = 16,
                    Name = "Sprinkles",
                    Image = "Sprinkles-image-base64",
                    Price = 10,
                    Stock = 200,
                    Description = " Baby shark sugar Sprinkles",
                    ProductTypeId = 3
                }
                );
        }
    }
}
