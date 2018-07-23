using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TeduShopData.Infrrastructure
{
    public interface IRepository<T> where T : class
    {
        // marks an enity as new
        T Add(T entity);
        // Marks an entity as modfied
        void Update(T entity);

        //Marks an entiy to be removed
        T Delete(T entity);
        T Delete(int id);
        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        //Get an entity by id
        T GetSingleById(int id);

        T GetSinglebyCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] include = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
        int Count(Expression<Func<T,bool>> where);
        bool CheckContrains(Expression<Func<T, bool>> predicate);


    }
}
