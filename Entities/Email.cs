using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Email
    {
        public int Id { get; set; }
        [Column("From_Email")]
        public string FromEmail { get; set; }
        [Column("To_Email")]
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        [Column("Email_Date")]
        public DateTime EmailDate { get; set; }
        public string Status { get; set; }
    }
}
