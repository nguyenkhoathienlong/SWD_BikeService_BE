using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactuerController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ManufactuerController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [ActionName("AddManufacturer")]
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> Add(ManufacturerRequest manufactureRequest)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Name = manufactureRequest.Name;
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddManufacturer", new { id = manufacturer.Id, manufactureRequest });
        }

    }
}
