using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.ReturnJsonModel
{
    public class ErrorJsonModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public ErrorJsonModel(int statusCode, IEnumerable<string>? errors = null, string? message = null)
        {
            StatusCode = statusCode;
            Errors = errors;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);

        }
       
        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource was not found",
                500 => "Errors are the path to the dark side.",
                _ => null
            };
        }
    }
}
