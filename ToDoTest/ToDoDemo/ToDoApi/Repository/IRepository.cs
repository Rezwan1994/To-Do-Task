using System.Linq.Expressions;
using ToDoApi.Model;

namespace ToDoApi.Repository
{
    public interface IRepository<TEntity, TKey>
     where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        TEntity GetById(TKey id);
        void Edit(TEntity entity);
        void Remove(TKey id);
        IList<TEntity> GetAll();
        int GetCount(Expression<Func<TEntity, bool>> filter = null);

    }
}
