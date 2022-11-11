using AutoMapper;
using BikeServiceProject_SWD.Helpers;
using BikeServiceProject_SWD.Models.Request;
using BikeServiceProject_SWD.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceProject_SWD.Controllers
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

        [HttpGet("get-all-product-active")]
        public IActionResult getAllProductActive()
        {
            var Product = _productService.GetAllActive();
            return Ok(Product);
        }

        [HttpGet("get-all-service")]
        public IActionResult getAllService()
        {
            var Product = _productService.GetAllService();
            return Ok(Product);
        }

        [HttpGet("get-all-service-active")]
        public IActionResult getAllServiceActive()
        {
            var Product = _productService.GetAllServiceActive();
            return Ok(Product);
        }

        [HttpGet("search-product/{name}")]
        public IActionResult searchByName(string name)
        {
            if (ModelState.IsValid)
            {
                var Product = _productService.GetByProductName(name);
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
