using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OA.Repo
{
    public interface IGenericRepository<T>  where T : class
    {
        IEnumerable<T> GetDetails();

        T GetById(int? id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        void SaveChanges();
    }
}
