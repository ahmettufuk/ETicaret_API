using ETicaret_API.Application.Absraction;
using ETicaret_API.Application.Repositories;
using ETicaret_API.Application.ViewModels.Products;
using ETicaret_API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public  async Task<IActionResult> Get()
        {

            //  await _productWriteRepository.AddAsync(new()
            //  {
            //      Id=Guid.NewGuid() , Name = "Product 1" ,Price = 100 ,CreatedDate=DateTime.UtcNow
            //  });
            // await  _productWriteRepository.SaveAsync();
            //return Ok();



            return Ok(_productReadRepository.GetAll(false));
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(WM_Create_Product model)
        {
            if (ModelState.IsValid)
            {

            }

            await _productWriteRepository.AddAsync(new() 
            {
               Name=model.Name,
               Stock=model.Stock,
               Price=model.Price
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(WM_Update_Product model)
        {
            Product product =await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.Remove(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

      



       
    }
}
