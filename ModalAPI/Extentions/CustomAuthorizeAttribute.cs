using Microsoft.AspNetCore.Authorization;

namespace Modal.APIs.Extentions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string Permission { get; set; }

        public CustomAuthorizeAttribute(string permission)
        {
            Permission = permission;
        }
    }
}