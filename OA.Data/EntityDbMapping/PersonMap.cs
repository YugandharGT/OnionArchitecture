using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.EntityDbMapping
{
    public class PersonMap
    {
        public PersonMap(EntityTypeBuilder<Person> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.FirstName).IsRequired();
            entityTypeBuilder.Property(t => t.LastName).IsRequired();
            entityTypeBuilder.Property(t => t.DOB).IsRequired();
            entityTypeBuilder.Property(t => t.Gender).IsRequired();
            entityTypeBuilder.Property(t => t.EmailId);
            entityTypeBuilder.Property(t => t.MobileNumber);
            entityTypeBuilder.Property(t => t.Nationality);
        }
    }
}
