using Microsoft.EntityFrameworkCore;
using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Specifications;
using Modal.Repository.Data;
using Modal.Repository.Interfaces;
using Modal.Repository.Specifications;

namespace Modal.Repository.Repositories
{
    public class GenaricRepository<IEntity> : IGenaricRepository<IEntity> where IEntity : BaseModel, new()
    {
        protected readonly ModalContext _context;

        public GenaricRepository(ModalContext context)
        {
            _context = context;
        }

        public async Task<IEntity?> GetAsync(ISpecifications<IEntity> spec)
        {
            return await SpecificationsEvaluator<IEntity>.CreateQuery(_context.Set<IEntity>(), spec).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<IEntity>> GetAllAsync(ISpecifications<IEntity> spec)
        {
            return await SpecificationsEvaluator<IEntity>.CreateQuery(_context.Set<IEntity>(), spec).Skip(spec.Skip).Take(spec.Take).ToListAsync();
        }

        public async Task<IEnumerable<IEntity>> GetAllWithoutPaginationAsync(ISpecifications<IEntity> spec)
        {
            return await SpecificationsEvaluator<IEntity>.CreateQuery(_context.Set<IEntity>(), spec).ToListAsync();
        }

        public async Task<int> GetCountAsync(ISpecifications<IEntity> spec)
        {
            return await SpecificationsEvaluator<IEntity>.CreateQuery(_context.Set<IEntity>(), spec).CountAsync();
        }

        public async Task<IEntity> AddAsync(IEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.IsActive = entity.IsActive == null ? true : entity.IsActive;
            await _context.Set<IEntity>().AddAsync(entity);
            //await SaveChangesAsync();
            _context.Entry(entity).GetDatabaseValues();
            return entity;
        }

        public async Task<IEntity> UpdateAsync(IEntity entity)
        {
            entity.IsActive = true;
            var existingEntity = await _context.Set<IEntity>().FindAsync(entity.ID);
            _context.Entry(existingEntity).State = EntityState.Detached;
            _context.Set<IEntity>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            //await SaveChangesAsync();
            _context.Entry(entity).GetDatabaseValues();
            return entity;
        }

        public async Task RemoveAsync(IEntity entity)
        {
            _context.Set<IEntity>().Remove(entity);
            //await SaveChangesAsync();

        }










        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
