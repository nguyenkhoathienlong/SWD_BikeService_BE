using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using BikeService.Models.Response;
using BikeService.Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("/get-all-product")]
        public IActionResult getAllProduct()
        {
            var Product = _productService.GetAll();
            return Ok(Product);
        }

        [HttpGet("/search-product/{name}")]
        public IActionResult searchByName(string name)
        {
            var Product = _productService.GetByName(name);
            return Ok(Product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Product = _productService.GetById(id);
            return Ok(Product);
        }

        [HttpPost]
        public IActionResult Create(ProductRequest productRequest)
        {
            _productService.Create(productRequest);
            return Ok(productRequest);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductRequest productRequest)
        {
            _productService.Update(id, productRequest);
            return Ok(productRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok(id);
        }
    }
}
