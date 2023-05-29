using MediatR;
using SugarShark.Application.CatalogModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Queries.GetProducts
{
    public class GetCatalogQuery : IRequest<Catalog>
    {
        //Search properties
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
