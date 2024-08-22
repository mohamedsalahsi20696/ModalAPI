using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsArchived { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
