using Ario_Hcm.Database.Models;

namespace Ario_Hcm.Database.Repositories
{
    public class SalaryRepository : Repository<Salary>
    {
        public SalaryRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
