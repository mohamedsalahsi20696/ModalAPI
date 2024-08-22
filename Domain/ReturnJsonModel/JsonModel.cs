using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.ReturnJsonModel
{
    public class JsonModel
    {
        public int StatusCode { get; set; }
        public object Obj { get; set; }
        public string Message { get; set; }

        public JsonModel(int statusCode, object obj, string? message = null)
        {
            StatusCode = statusCode;
            Obj = obj;
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
