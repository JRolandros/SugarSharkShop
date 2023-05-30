using SugarShark.Application.CatalogModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Services
{
    public interface ICatalogService
    {
        Task<ProductDto> GetProductById(int v);
        Task<List<ProductDto>> GetProducts();
        Task<List<ProductDto>> GetProducts(string type);
        Task<List<ProductDto>> GetProducts(string type, string name);
    }
}
