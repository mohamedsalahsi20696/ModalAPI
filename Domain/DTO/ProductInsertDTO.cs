using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Models;

namespace Modal.Domain.DTO
{
    public class ProductInsertDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PictureURL { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid BrandID { get; set; }
        [Required]
        public Guid CategoryID { get; set; }
    }
}
