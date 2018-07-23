 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeduShopData;
using TeduShopData.Infrrastructure;

namespace TeDuShopData.Infrrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private TeDuShopDbContext dataContext;
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected TeDuShopDbContext DbContext { get { return dataContext ?? (dataContext = DbFactory.Init()); } }
        #endregion
        protected RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        #region Implemmentation

        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public bool CheckContrains(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if(includes != null && includes.Count()>0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsQueryable();
            }
            return dataContext.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
           if(includes != null && includes.Count()>0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes)
                {
                    query = query.Include(include);
                    return query.Where<T>(predicate).AsQueryable<T>();
                }
               

            }
            return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = filter != null ? query.Where<T>(filter).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = filter != null ? dataContext.Set<T>().Where<T>(filter).AsQueryable() : dataContext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public T GetSinglebyCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public T GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }
}
