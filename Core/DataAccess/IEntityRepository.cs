using Core.Entities;
using System.Linq.Expressions;

namespace Core.Abstract
{ 
    // Generic Constraint: Bu sınıf IEntity'den türemiş olmalı ve new() ile türetilebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>>? filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
