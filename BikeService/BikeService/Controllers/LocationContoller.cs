using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationContoller : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public LocationContoller(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [ActionName("AddArea")] //CREATE
        [HttpPost("/add-area")]
        public async Task<ActionResult<Area>> Add(AreaRequest areaRequest)
        {
            Area area = new Area();
            area.Name = areaRequest.Name;
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddArea", new { id = area.Id }, areaRequest);
        }


        [ActionName("UpdateArea")] //UPDATE
        [HttpPut("/update-area/{id}")]
        public async Task<ActionResult<Area>> Update(int id, AreaRequest areaRequest)
        {
            return null;
        }

        [ActionName("DeleteArea")]
        [HttpDelete("delete-area/{id}")]
        public async Task<ActionResult<Area>> Delete(int id, Area area)
        {
            return null;
        }

    }
}
