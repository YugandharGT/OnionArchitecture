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
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly CoreDbContext db;

        public EmployeeTaskRepository(CoreDbContext context)
        {
            db = context;
        }

        #region Asynchronous Db Activities
        public async Task<Employee> GetByIdAsync(int? id)
        {
            if (db != null)
            {
                return await db.Set<Employee>().FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            if (db != null) 
            {
                return await db.Set<Employee>().ToListAsync();
            }
            return null;
        }

        public async Task<Employee> InsertAsync(Employee entity) //int
        {
            var result = await db.AddAsync(entity);
            //SaveAsync();
            await db.SaveChangesAsync();
            return result.Entity; //entity.Id;
            
        }

        public async Task<Employee> RemoveAsync(int id)
        {
            var remRecord = await db.Set<Employee>().FirstOrDefaultAsync(x => x.Id == id);
            if (remRecord != null)
            {
                db.Remove(remRecord);
                //db.Entry(remRecord).State = EntityState.Deleted; //Tracks
                await db.SaveChangesAsync();
                return remRecord;
            }
            return null;

        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            var updtRecord = await db.Set<Employee>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (updtRecord != null)
            {
                updtRecord.Name = entity.Name;
                updtRecord.Email = entity.Email;
                updtRecord.Department = entity.Department;
                db.Update(updtRecord);
                await db.SaveChangesAsync();
                return updtRecord;
            }
            return null;
        }
        
        /// <summary>
        /// Commit the transaction
        /// </summary>
        private async void SaveAsync()
        {
           await db.SaveChangesAsync();
        }
        #endregion

        public async Task<IEnumerable<Employee>> Search(string name)
        {
            var query = db.Set<Employee>().AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name) || e.Email.Contains(name) || e.Department.Contains(name));
            }
            return await query.ToListAsync();
        }
    }
}
