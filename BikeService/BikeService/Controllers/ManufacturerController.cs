using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class ManufactuerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IManufacturerService _manufacturerService;

        public ManufactuerController(IManufacturerService manufacturerService, IMapper mapper)
        {
            _manufacturerService = manufacturerService;
            _mapper = mapper;
        }

        [HttpGet("/get-all-manufacturer")]
        public IActionResult getAllManufacturer()
        {
            var manufacturer = _manufacturerService.GetAll();
            return Ok(manufacturer);
        }

        [HttpGet("/search-manufacturer/{name}")]
        public IActionResult searchByName(string name)
        {
            var manufacturer = _manufacturerService.GetByName(name);
            return Ok(manufacturer);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var manufacturer = _manufacturerService.GetById(id);
            return Ok(manufacturer);
        }

        [HttpPost]
        public IActionResult Create(ManufacturerRequest manufactureRequest)
        {
            _manufacturerService.Create(manufactureRequest);
            return Ok(manufactureRequest);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ManufacturerRequest manufactureRequest)
        {
            _manufacturerService.Update(id, manufactureRequest);
            return Ok(manufactureRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _manufacturerService.Delete(id);
            return Ok(id);
        }
    }
}
