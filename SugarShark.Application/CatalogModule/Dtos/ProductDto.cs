using SugarShark.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Dtos
{
    public class ProductDto : BaseProductDto
    {
        public string Description { get; set; }
        public int Stock { get; set; }

    }
}
