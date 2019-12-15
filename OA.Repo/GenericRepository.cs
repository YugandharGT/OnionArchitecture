using Microsoft.EntityFrameworkCore;
using OA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OA.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CoreDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public GenericRepository(CoreDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Remove(entity);
            SaveChanges();
        }

        public T GetById(object id) //object id
        {
            var entity = entities.Find(id);
            return entity;
        }

        public IEnumerable<T> GetDetails()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            SaveChanges();
        }
    }
}
