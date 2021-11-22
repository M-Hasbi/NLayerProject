using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
   public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id); //gets a entity(product or category) by id

        Task<IEnumerable<TEntity>> GetAllAsync(); // gets all the entities.

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); // Works with the expression for example: Find(x=>x.id=23) points the expression method in order to find
                                                                                    // given id
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); //the mechanism is alike with previous method, for example: category.SingleOrDefaultAsync(x=>x.name = "pencil") 

        Task<TEntity> AddAsync(TEntity entity); //adds a entity

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities); // adds multiple entities.

        void Remove(TEntity entity); // removes a entity

        void RemoveRange(IEnumerable<TEntity> entities); // removes multiple entities.

        TEntity Update(TEntity entity); // update an entity.
    }
}
