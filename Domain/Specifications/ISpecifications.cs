using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.Specifications
{
    public interface ISpecifications<IEntity> where IEntity : BaseModel
    {
        public Expression<Func<IEntity, bool>> Criteria { get; set; }
        public List<Expression<Func<IEntity, object>>> Includes { get; set; }
        public Expression<Func<IEntity, object>> OrderBy { get; set; }
        public Expression<Func<IEntity, object>> OrderByDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }


    }
}
