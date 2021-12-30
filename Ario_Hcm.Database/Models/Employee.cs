using System;
using System.Collections.Generic;

namespace Ario_Hcm.Database.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phonr { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }

        public virtual IEnumerable<Assignment> Assignments { get; set; }
    }
}
