﻿using ETicaret_API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Application.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
    }
}
