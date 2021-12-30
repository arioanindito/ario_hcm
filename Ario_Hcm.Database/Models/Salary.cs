using System;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Ario_Hcm.Database.Models
{
    public class Salary : DatabaseModel
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}
