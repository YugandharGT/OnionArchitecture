using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.EntityDbMapping
{
    public class EmailMap
    {
        public EmailMap(EntityTypeBuilder<Email> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.FromEmail);
            entityTypeBuilder.Property(t => t.ToEmail);
            entityTypeBuilder.Property(t => t.EmailDate);
            entityTypeBuilder.HasKey(t => t.Subject);
            entityTypeBuilder.Property(t => t.Status);
        }
    }
}
