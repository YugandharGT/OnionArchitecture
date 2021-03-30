using Entities;
using OA.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServices.Test
{
    public class DummyDataDBInitializer
    {

        public DummyDataDBInitializer()
        {

        }

        public void Seed(CoreDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Employees.AddRange(
                new Employee() { Name = "Yugandhar", Email = "tyugandharyuvaraj@gmail.com", Department="IT" },
                new Employee() { Name = "Rajesh", Email = "Rajesh@147@gmail.com", Department = "Testing" },
                new Employee() { Name = "AjithKumar", Email = "ajithkumar958@gmail.com", Department = "Media&Telecomunnication" }
            );
            context.SaveChanges();
        }
    }
}
