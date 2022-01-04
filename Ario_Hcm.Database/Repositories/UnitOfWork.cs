using System.Threading.Tasks;
using Ario_Hcm.Core.Database;

namespace Ario_Hcm.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isComited = false;
        private readonly IDatabaseContext _context;

        public UnitOfWork(IDatabaseContext context)
        {
            _context = context;
        }

        public Task CommitAsync()
        {
            if (_isComited)
            {
                return Task.CompletedTask;
            }

            _isComited = true;
            return _context.CommitAsync();
        }

        public void Dispose()
        {
            RollbackAsync()
                .GetAwaiter()
                .GetResult();
        }

        public Task RollbackAsync()
        {
            if (!_isComited)
            {
                return Task.CompletedTask;
            }

            return _context.RollbackAsync();
        }
    }
}
