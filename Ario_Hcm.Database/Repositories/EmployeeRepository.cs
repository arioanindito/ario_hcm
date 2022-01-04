using Ario_Hcm.Database.Models;

namespace Ario_Hcm.Database.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
