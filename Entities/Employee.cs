using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
    }
}

