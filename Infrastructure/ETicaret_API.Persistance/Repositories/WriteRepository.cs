using ETicaret_API.Application.Repositories;
using ETicaret_API.Domain.Entities.Common;
using ETicaret_API.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Persistance.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ETicaret_API_DbContext _context;

        public WriteRepository(ETicaret_API_DbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
           var entityEntry= await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(TEntity entity)
        {
            var entityEntry =Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> Remove(string id)
        {
            var model =await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            return Remove(model);
        }

        public bool RemoveRange(List<TEntity> entities)
        {
           Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync()
        =>  await _context.SaveChangesAsync();

        public bool Update(TEntity entity)
        {
            var entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
