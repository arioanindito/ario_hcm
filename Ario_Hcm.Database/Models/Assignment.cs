using System;
using System.Collections.Generic;
using Ario_Hcm.Core.Database;

namespace Ario_Hcm.Database.Models
{
    public class Assignment : DatabaseModel
    {
        public string JobTitle { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
        public virtual IEnumerable<Salary> Sallaries { get; set; }
    }
}