using Microsoft.EntityFrameworkCore;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.Common;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.CatalogModule.Repositories
{
    public class ProductRepository : BaseRepository,IProductRepository
    {
        private readonly ISugarSharkDbContext _dbContext;

        public ProductRepository(ISugarSharkDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductById(int id)
        {
            var product = _dbContext
                .Products
                .Include(p=>p.ProductType)
                .FirstOrDefault(p => p.Id == id);

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _dbContext
                .Products
                .Include(p => p.ProductType)
                .AsEnumerable();

            return products;
        }
    }
}
