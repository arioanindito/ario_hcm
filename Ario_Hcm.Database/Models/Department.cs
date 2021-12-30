using System;
using System.Collections.Generic;

namespace Ario_Hcm.Database.Models
{
    public class Department
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Assignment> Assignments { get; set; }
    }
}
