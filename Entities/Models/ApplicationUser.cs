using Entities.Contracts;
using Microsoft.AspNetCore.Identity;
using System;

namespace Entities.Models
{
    /// <summary>
    /// It represents login user attributes
    /// </summary>
    public class ApplicationUser :  IdentityUser, IAuditableEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
