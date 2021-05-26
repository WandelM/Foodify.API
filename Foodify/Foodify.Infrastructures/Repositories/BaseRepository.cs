using Foodify.Domain.Models;
using Foodify.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foodify.Infrastructures.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly FoodifyContext _context;
        protected readonly DbSet<T> _dbEntities;

        public BaseRepository(FoodifyContext context)
        {
            _context = context ?? throw new NullReferenceException();
            _dbEntities = context.Set<T>();
        }

        public virtual void Add(T model)
        {
            _dbEntities.Add(model);
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbEntities.ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid modelId)
        {
            return await _dbEntities.FindAsync(modelId);
        }

        public virtual void Remove(T model)
        {
            _dbEntities.Remove(model);
        }

        public virtual void SaveChanges()
        {
            if (_context.ChangeTracker.HasChanges())
                _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            if (_context.ChangeTracker.HasChanges())
                await _context.SaveChangesAsync();
        }

        public void Update(T model)
        {
            _dbEntities.Update(model);
        }
    }
}
