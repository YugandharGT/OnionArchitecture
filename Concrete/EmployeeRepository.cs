using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiHelper;
using Entities;
using Microsoft.EntityFrameworkCore;
using OA.Data.Context;
using OA.Interface;

namespace OA.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CoreDbContext db;

        public EmployeeRepository(CoreDbContext context)
        {
            db = context;
        }

        public async Task<Employee> GetById(int? id)
        {
            if (db != null)
            {
                return await db.Set<Employee>().FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            if (db != null) 
            {
                return await db.Set<Employee>().ToArrayAsync();
            }
            return null;
        }

        public async Task<int> Insert(Employee entity)
        {
            if (db != null)
            {
                 await db.AddAsync(entity);
                 //db.SaveChanges();
                 SaveAsync();
                 return entity.Id;
            }
            return 0;
        }

        public async Task<int> Remove(int? id)
        {
            var result = 0;
            if (db != null)
            {
                var remRecord = await db.Set<Employee>().FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (remRecord != null)
                {
                    db.Remove(remRecord);
                    //db.Entry(remRecord).State = EntityState.Deleted; //Tracks
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task Update(int id, Employee entity)
        {
            if (db != null)
            {
                var updtRecord = await db.Set<Employee>().FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (updtRecord != null)
                {
                    updtRecord.Name = entity.Name;
                    updtRecord.Email = entity.Email;
                    updtRecord.Department = entity.Department;
                    db.Update(updtRecord);
                    await db.SaveChangesAsync();
                }
            }
        }
        
        /// <summary>
        /// Commit the transaction
        /// </summary>
        private async void SaveAsync()
        {
           await db.SaveChangesAsync();
        }

    }
}
