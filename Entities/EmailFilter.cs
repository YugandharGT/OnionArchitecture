using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    
    public class EmailFilter
    {
        public string EmailId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public EmailStatus Status { get; set; }
    }

    public enum EmailStatus
    {
        All =0,
        Submitted = 1,
        Released = 2,
    }
}
