using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.DTO
{
    public class ProductSpecificationsParamtersDTO
    {
        public string? Sort { get; set; }
        public string? BrandId { get; set; }
        public string? CategoryId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }
}
