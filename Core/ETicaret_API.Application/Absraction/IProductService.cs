using ETicaret_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Application.Absraction
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
