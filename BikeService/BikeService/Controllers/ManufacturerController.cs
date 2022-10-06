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


        [ActionName("AddManufacturer")]
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> Add(ManufacturerRequest manufactureRequest)
        {
            _manufacturerService.Create(manufactureRequest);
            return Ok(new { message = "Created!!" });
        }

    }
}
