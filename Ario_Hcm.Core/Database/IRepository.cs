using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ario_Hcm.Core.Database
{
    public interface IRepository<TEntity>
        where TEntity : DatabaseModel
    {
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<string> SaveAsync(TEntity entity);
        Task<string> UpdateAsync(TEntity entity);
        Task<string> DeleteAsync(TEntity entity);
        IQueryable<TEntity> Query();
    }
}
