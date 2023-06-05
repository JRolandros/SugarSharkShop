using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SugarShark.Application.Common
{
    public class SugarSharkException : Exception
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public int StatusCode { get; set; }

        public SugarSharkException(string detail, Exception ex, int statusCode=500) :base(detail, ex)
        {
            Detail = detail;
            statusCode = statusCode;
        }
    }
}
