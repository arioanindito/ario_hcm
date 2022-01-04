using Ario_Hcm.Database.Models;

namespace Ario_Hcm.Database.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
