using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace NLayerProject.Data.Repositories
{
    public class Repositories<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repositories(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        // Task is here corresponds to void method that in synchrone  programming. 
        // In async programming we use Task for Void method that is in synchrone programming.
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity); // await keyword used for waiting untill process is finished.
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        // this is 
        // an example for delegate method. Delegates referances to the specific methods. Here for example 
        // our delegate referances a function that get TEntity and returns a bool called predicate. 
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified; //This method updates all of our columns
            //if we want to update just one specific column, than it can cause losing of performance.
            return entity;
        }
    }
}
