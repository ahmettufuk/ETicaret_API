using ETicaret_API.Application.Absraction;
using ETicaret_API.Application.Repositories;
using ETicaret_API.Application.RequestParameters;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository,IWebHostEnvironment webHostEnvironment)
        {
            _productWriteRepository= productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment= webHostEnvironment;
        }

        [HttpGet]
        public  async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {

            //  await _productWriteRepository.AddAsync(new()
            //  {
            //      Id=Guid.NewGuid() , Name = "Product 1" ,Price = 100 ,CreatedDate=DateTime.UtcNow
            //  });
            // await  _productWriteRepository.SaveAsync();
            //return Ok();



            // return Ok(_productReadRepository.GetAll(false));
            var totalCount = _productReadRepository.GetAll(false).Count();
           var products=  _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size)
            .Take(pagination.Size)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();
            return Ok(new {totalCount,products});
            
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
            return Ok(new
            {
                message = "Product Deleted!"
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"resource/product-images");
            Random r = new();
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            foreach(IFormFile file in Request.Form.Files)
            {
                string fullPath=Path.Combine(uploadPath,$"{r.Next()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }

      



       
    }
}
