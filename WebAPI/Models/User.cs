using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Models
{
    /// <summary>
    /// It represents login user attributes
    /// </summary>
    public class User
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
