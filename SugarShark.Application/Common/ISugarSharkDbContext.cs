using Microsoft.EntityFrameworkCore;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Common
{
    public interface ISugarSharkDbContext
    {
        DbSet<Product> Products { get; }

        DbSet<ProductType> ProductTypes { get; }

    }
}
