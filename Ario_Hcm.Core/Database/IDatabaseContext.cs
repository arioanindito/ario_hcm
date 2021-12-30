using System;
using System.Threading.Tasks;

namespace Ario_Hcm.Core.Database
{
    public interface IDatabaseContext
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}
