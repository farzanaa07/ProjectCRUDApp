using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectCRUDApp.Data;

namespace ProjectCRUDApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    { 
       protected ApplicationDbContext RepositoryContext { get; set; }
       public Repository(ApplicationDbContext repositoryContext) //dependency injection to inject the class
        {
            RepositoryContext = repositoryContext; 
        }
        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity; //set<T> takes whatever class is being passed in the generic class
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            return RepositoryContext.Set<T>().Update(entity).Entity;
        }
    }

}
