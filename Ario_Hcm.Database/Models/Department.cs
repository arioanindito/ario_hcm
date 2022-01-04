using System.Collections.Generic;
using Ario_Hcm.Core.Database;

namespace Ario_Hcm.Database.Models
{
    public class Department : DatabaseModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Assignment> Assignments { get; set; }
    }
}
