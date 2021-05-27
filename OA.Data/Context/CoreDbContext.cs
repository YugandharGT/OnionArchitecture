using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OA.Data.EntityDbMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Context
{
    public class CoreDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new EmployeeMap(modelBuilder.Entity<Employee>());
            //new EmailMap(modelBuilder.Entity<Email>());

        }

        public DbSet<Employee> Employees;
        public DbSet<Email> Emails;
    }
}
