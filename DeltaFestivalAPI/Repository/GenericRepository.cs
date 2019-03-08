using DeltaFestivalAPI.Database;
using DeltaFestivalAPI.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestivalAPI.Repository
{
    public abstract class GenericRepository<T> :
    IGenericRepository<T> where T : class, new()
    {

        private readonly DeltaDbContext _dbContext;


        public GenericRepository(DeltaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> GetAll()
        {

            return _dbContext.Set<T>();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            //_entities.Entry(entity).State = System.Data.EntityState.Modified;
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
