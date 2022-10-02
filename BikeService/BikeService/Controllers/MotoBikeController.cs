using BikeService.Data;
using BikeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoBikeController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MotoBikeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motorbike>>> getAllMotor()
        {
            return await _context.Motorbikes.ToListAsync();
        }

        [HttpPost("/themThongtinMoto")]
        public async Task<ActionResult<Motorbike>> Add(Motorbike moto)
        {
            _context.Motorbikes.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMotorbike", new { id = moto.Id }, moto);
        }

    }
}
