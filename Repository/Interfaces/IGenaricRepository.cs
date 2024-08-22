using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Specifications;

namespace Modal.Repository.Interfaces
{
    public interface IGenaricRepository<IEntity> where IEntity : BaseModel
    {
        public Task<IEntity?> GetAsync(ISpecifications<IEntity>? spec);
        public Task<IEnumerable<IEntity>> GetAllAsync(ISpecifications<IEntity>? spec);
        public Task<IEnumerable<IEntity>> GetAllWithoutPaginationAsync(ISpecifications<IEntity>? spec);
        public Task<int> GetCountAsync(ISpecifications<IEntity>? spec);
        Task<IEntity> AddAsync(IEntity entity);
        Task<IEntity> UpdateAsync(IEntity entity);
        Task RemoveAsync(IEntity entity);







        //void SaveChanges();
    }
}
