using AutoMapper;
using BikeService.Helpers;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("get-all-product")]
        public IActionResult getAllProduct()
        {
            var Product = _productService.GetAll();
            return Ok(Product);
        }

        [HttpGet("search-product/{name}")]
        public IActionResult searchByName(string name)
        {
            if (ModelState.IsValid)
            {
                var Product = _productService.GetByName(name);
                return Ok(Product);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
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
            if (ModelState.IsValid)
            {
                _productService.Create(productRequest);
                return Ok(productRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(id, productRequest);
                return Ok(productRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok(id);
        }
    }
}
