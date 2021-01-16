using DAL.Context;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected InventoryDbContext Context { get; set; }

        public RepositoryBase(InventoryDbContext context)
        {
            this.Context = context;
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return Context.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
