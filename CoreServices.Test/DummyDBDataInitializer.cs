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
            
            context.employees.AddRange(
                new Employee() { Name = "CSHARP", Email = "csharp", Department="Programming" },
                new Employee() { Name = "VISUAL STUDIO", Email = "visualstudio", Department = "Software" },
                new Employee() { Name = "ASP.NET CORE", Email = "aspnetcore", Department = "Framework" },
                new Employee() { Name = "SQL SERVER", Email = "sqlserver", Department = "Database" }
            );

            context.SaveChanges();
        }
    }
}
