using ETicaret_API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Application.Repositories
{
    public interface IWriteRepository<TEntity> :
        IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        bool RemoveRange(List<TEntity> entities);
        Task<bool> Remove(string id);

        Task<int> SaveAsync();
    }
}
