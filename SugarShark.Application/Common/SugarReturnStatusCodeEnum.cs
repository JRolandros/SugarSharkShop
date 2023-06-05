using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Common
{
    public enum SugarReturnStatusCodeEnum
    {
        BadRequest=400,
        NotFound=404,
        ServerError=500,
        Unauthorized=401,
        Forbidden=403
    }
}
