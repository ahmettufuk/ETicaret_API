using ETicaret_API.Application.Repositories;
using ETicaret_API.Domain.Entities;
using ETicaret_API.Persistance.Contexts;
using ETicaret_API.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Persistance.Concretes
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ETicaret_API_DbContext context) : base(context)
        {
        }
    }
}
