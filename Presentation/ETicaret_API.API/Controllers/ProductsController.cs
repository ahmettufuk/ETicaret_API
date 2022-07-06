using ETicaret_API.Application.Absraction;
using ETicaret_API.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository= productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        
        public  async Task Get()
        {
         /* 
            await _productWriteRepository.AddAsync(new()
            {
                Id=Guid.NewGuid() , Name = "Product 1" ,Price = 100 ,CreatedDate=DateTime.UtcNow
            });
           var count = await  _productWriteRepository.SaveAsync();
            
            var p = await _productReadRepository.GetByIdAsync("ef4da674-5bbb-4c92-9a1e-3e3ee72a9980");
            p.Name = "Enginqq";
            await _productWriteRepository.SaveAsync();
         */
        }

      



       
    }
}
