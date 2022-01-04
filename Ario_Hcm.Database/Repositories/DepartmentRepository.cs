using Ario_Hcm.Database.Models;

namespace Ario_Hcm.Database.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
