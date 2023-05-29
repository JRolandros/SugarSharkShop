using SugarShark.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
