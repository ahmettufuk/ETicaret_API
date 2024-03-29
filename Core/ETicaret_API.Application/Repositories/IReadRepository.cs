﻿using ETicaret_API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(bool tracking =true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity,bool>> method, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method , bool tracking = true);
        Task<TEntity> GetByIdAsync(string id, bool tracking = true);

    }
}
