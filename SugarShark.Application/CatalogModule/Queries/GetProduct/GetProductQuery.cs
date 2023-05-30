using MediatR;
using SugarShark.Application.CatalogModule.Dtos;

namespace SugarShark.Application.CatalogModule.Queries.GetProduct
{
    public class GetProductQuery :IRequest<ProductDto>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}