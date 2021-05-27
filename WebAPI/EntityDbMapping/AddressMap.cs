using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.EntityDbMapping
{
    public class AddressMap
    {
        public AddressMap(EntityTypeBuilder<Address> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.TemporaryAdress);
            entityTypeBuilder.Property(t => t.TempCity);
            entityTypeBuilder.Property(t => t.TempState);
            entityTypeBuilder.Property(t => t.TempPincode);
            entityTypeBuilder.Property(t => t.TempCountry);
            entityTypeBuilder.Property(t => t.PermanentAdress).IsRequired();
            entityTypeBuilder.Property(t => t.PermCity).IsRequired();
            entityTypeBuilder.Property(t => t.PermState).IsRequired();
            entityTypeBuilder.Property(t => t.PermPincode).IsRequired();
            entityTypeBuilder.Property(t => t.PermCountry).IsRequired();
            entityTypeBuilder.Property(t => t.IsSameAsPermanent);
            entityTypeBuilder.HasIndex(t => t.PersonId);

            entityTypeBuilder.HasOne(n => n.People)
                             .WithMany(c => c.Addresses)
                             .HasForeignKey(c => c.PersonId);
        }
    }
}
