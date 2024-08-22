using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Models;
using Modal.Domain.Specifications;

namespace Modal.Repository.Specifications
{
    internal static class SpecificationsEvaluator<IEntity> where IEntity : BaseModel
    {
        public static IQueryable<IEntity> CreateQuery(IQueryable<IEntity> dbQuery, ISpecifications<IEntity> specifications)
        {
            var query = dbQuery;

            if (specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            if (specifications.Includes is not null)
                query = specifications.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            if (specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);

            if (specifications.OrderByDesc is not null)
                query = query.OrderByDescending(specifications.OrderByDesc);

            return query;
        }
    }
}
