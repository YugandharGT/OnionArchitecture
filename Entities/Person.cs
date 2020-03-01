using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Nationality { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
