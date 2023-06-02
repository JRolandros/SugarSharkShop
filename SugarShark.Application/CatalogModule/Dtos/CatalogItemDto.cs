using SugarShark.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Dtos
{
    public class CatalogItemDto : BaseProductDto
    {
        public int MaxQty { get; set; }

    }
}
