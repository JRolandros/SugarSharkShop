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
        Task<List<CatalogItemDto>> GetCatalogItems();
        Task<List<CatalogItemDto>> GetCatalogItems(string type);
        Task<List<CatalogItemDto>> GetCatalogItems(string type, string name);
    }
}
