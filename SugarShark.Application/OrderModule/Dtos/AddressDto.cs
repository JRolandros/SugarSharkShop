using SugarShark.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.OrderModule.Dtos
{
    public class AddressDto : BaseDto
    {
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
