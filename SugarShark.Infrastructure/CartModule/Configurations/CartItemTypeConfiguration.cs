using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.CartModule.Configurations
{
    public class CartItemTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>new {x.ProductId,x.CartId}).IsUnique();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasData(
                new CartItem
                {
                    Id = 1,
                    CartId = 2,
                    ProductId = 11,
                    Quantity = 2
                },
                new CartItem
                {
                    Id = 2,
                    CartId = 2,
                    ProductId = 12,
                    Quantity = 1
                },
                new CartItem
                {
                    Id = 3,
                    CartId = 2,
                    ProductId = 13,
                    Quantity = 10
                },
                new CartItem
                {
                    Id = 4,
                    CartId = 4,
                    ProductId = 12,
                    Quantity = 5
                }
                );
        }
    }
}
