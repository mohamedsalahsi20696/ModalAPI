using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.Specifications
{
    public class Specifications<IEntity> : ISpecifications<IEntity> where IEntity : BaseModel
    {
        public Expression<Func<IEntity, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<IEntity, object>>> Includes { get; set; } = new List<Expression<Func<IEntity, object>>>();
        public Expression<Func<IEntity, object>> OrderBy { get; set; } = null; 
        public Expression<Func<IEntity, object>> OrderByDesc { get; set; } = null;
        public int Skip { get ; set ; }
        public int Take { get ; set; }
        public bool IsPaginationEnabled { get; set; }

        // this constructor to if user needed every thing in table without Criteria
        public Specifications()
        {

        }

        // this constructor to if user needed special some thing in table
        public Specifications(Expression<Func<IEntity, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }

    }
}
