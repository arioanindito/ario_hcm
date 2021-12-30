using System;
using System.Threading.Tasks;

namespace Ario_Hcm.Core.Database
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
