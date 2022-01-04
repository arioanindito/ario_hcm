using Ario_Hcm.Database.Models;

namespace Ario_Hcm.Database.Repositories
{
    public class AssignmentRepository : Repository<Assignment>
    {
        public AssignmentRepository(DatabaseContext context)
            : base (context)
        {

        }
    }
}
