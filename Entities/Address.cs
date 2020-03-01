using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    
    public class Address
    {
        public int Id { get; set; }
        public string TemporaryAdress { get; set; }
        public string TempCity { get; set; }
        public string TempState { get; set; }
        public string TempPincode { get; set; }
        public string TempCountry{ get; set; }

        public string PermanentAdress { get; set; }
        public string PermCity { get; set; }
        public string PermState { get; set; }
        public string PermPincode { get; set; }
        public string PermCountry { get; set; }

        public bool IsSameAsPermanent { get; set; }


        public int PersonId { get; set; }
        public Person People { get; set; }
    }
}
