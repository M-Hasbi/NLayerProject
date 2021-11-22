using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
   public interface IRepository<TEntity> where TEntity : class
        #region  What is IEnumerable in C#? 

        /* 
         IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.
          Key Points
          IEnumerable interface contains the System.Collections.Generic namespace.
          IEnumerable interface is a generic interface which allows looping over generic or non-generic lists.
          IEnumerable interface also works with linq query expression.
          IEnumerable interface Returns an enumerator that iterates through the collection.
        */

        #endregion
    {
        Task<TEntity> GetByIdAsync(int id); //gets a entity(product or category) by id

        Task<IEnumerable<TEntity>> GetAllAsync(); // gets all the entities.

        Task<IEnumerable<TEntity>>Where(Expression<Func<TEntity, bool>> predicate); // Works with the expression for example: Find(x=>x.id=23) points the expression method in order to find
                                                                                    // given id
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); //the mechanism is alike with previous method, for example: category.SingleOrDefaultAsync(x=>x.name = "pencil") 

        Task AddAsync(TEntity entity); //adds a entity

        Task AddRangeAsync(IEnumerable<TEntity> entities); // adds multiple entities.

        void Remove(TEntity entity); // removes a entity

        void RemoveRange(IEnumerable<TEntity> entities); // removes multiple entities.

        TEntity Update(TEntity entity); // update an entity.


    }
}
