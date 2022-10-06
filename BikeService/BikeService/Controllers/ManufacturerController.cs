using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var manufacturer = _manufacturerService.GetById(id);
            return Ok(manufacturer);
        }

        [HttpPost]
        public async Task<ActionResult<Manufacturer>>Create(ManufacturerRequest manufactureRequest)
        {
            _manufacturerService.Create(manufactureRequest);
            return Ok(new { message = "Created!!" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ManufacturerRequest manufactureRequest)
        {
            _manufacturerService.Update(id, manufactureRequest);
            return Ok(new { message = "Updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _manufacturerService.Delete(id);
            return Ok(new { message = "Deleted" });
        }



    }
}
