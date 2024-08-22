using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.ReturnJsonModel
{
    public class SuccessJsonModel
    {
        public int StatusCode { get; set; }
        public object Obj { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? TotalRecords { get; set; }
        public string Message { get; set; }

        public SuccessJsonModel(int statusCode, object obj, int pageIndex = 1, int pageSize = 1, int totalRecords = 0, string? message = null)
        {
            StatusCode = statusCode;
            Obj = obj;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                _ => null
            };
        }
    }
}
