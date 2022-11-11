using AutoMapper;
using BikeServiceProject_SWD.Helpers;
using BikeServiceProject_SWD.Models.Request;
using BikeServiceProject_SWD.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceProject_SWD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("get-all-category")]
        public IActionResult getAllCategory()
        {
            var category = _categoryService.GetAll();
            return Ok(category);
        }

        [HttpGet("search-category/{name}")]
        public IActionResult searchByName(string name)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryService.GetByName(name);
                return Ok(category);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CategoryRequest categoryRequest)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(categoryRequest);
                return Ok(categoryRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryRequest categoryRequest)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(id, categoryRequest);
                return Ok(categoryRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok(id);
        }
    }
}
