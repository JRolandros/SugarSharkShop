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
    public class CartTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.CartItems);
            builder.HasIndex(x => x.UserId).IsUnique();

            //Seed
            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Cart> builder)
        {
            builder.HasData(
                new Cart()
                {
                    Id = 2,
                    UserId = 2,
                    ValidityEndDate = DateTime.Now.AddDays(2),
                },
                new Cart()
                {
                    Id = 4,
                    UserId = 1,
                    ValidityEndDate = DateTime.Now.AddDays(2),
                }

                );
        }
    }
}
