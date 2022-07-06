using ETicaret_API.Application.Repositories;
using ETicaret_API.Domain.Entities.Common;
using ETicaret_API.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Persistance.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ETicaret_API_DbContext _context;

        public ReadRepository(ETicaret_API_DbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
               query= query.AsNoTracking();
            }
            return query;
        }
            


        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        {
            //await Table.SingleOrDefaultAsync(p => p.Id== Guid.Parse(id));
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(p=> p.Id==Guid.Parse(id));
        } 

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            //await Table.SingleOrDefaultAsync(p => p.Id== Guid.Parse(id));
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query=Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        } 
    }
}
