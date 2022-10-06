using BikeService.Data;
using BikeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationContoller : ControllerBase
    {
        private readonly MyDbContext _context;

        public LocationContoller(MyDbContext context)
        {
            _context = context;
        }
        
        [ActionName("AddArea")] //CREATE
        [HttpPost("/add-area")]
        public async Task<ActionResult<Area>> Add(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddArea", new { id = area.Id }, area);
        }


        [ActionName("UpdateArea")] //UPDATE
        [HttpPut("/update-area")]
        public async Task<ActionResult<Area>> Update(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }
            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
            return CreatedAtAction("UpdateArea", new {id = area.Id}, area);
        }

    }
}
