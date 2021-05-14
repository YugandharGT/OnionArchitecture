using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Queries
{
    /// <summary>
    /// It holds the response of retrieving eamils history 
    /// </summary>
    public class GetAllEmailsResponse
    {
        public int Id { get; set; }
        
        public string FromEmail { get; set; }
        
        public string ToEmail { get; set; }
        
        public string Subject { get; set; }
        
        public DateTime EmailDate { get; set; }
        
        public string Status { get; set; }
    }
}
