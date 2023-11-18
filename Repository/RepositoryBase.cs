using EcommerceApplication.Data.Interfaces;
using System.Linq.Expressions;

namespace EcommerceApplication.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly StoreContext _storeContext;

        public RepositoryBase(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }  

        public IQueryable<T> FindAll()
        {
            return _storeContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _storeContext.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            _storeContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _storeContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _storeContext.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _storeContext.SaveChanges();
        }
    }
}
