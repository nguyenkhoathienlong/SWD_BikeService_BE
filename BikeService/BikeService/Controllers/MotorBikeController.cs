using AutoMapper;
using BikeService.Helpers;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    [Authorize]
    public class MotorBikeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IMotorbikeService _motorbikeService;

        public MotorBikeController(IMotorbikeService motorbikeService, IMapper mapper)
        {
            _motorbikeService = motorbikeService;
            _mapper = mapper;
        }

        [HttpGet("get-all-motorbike")]
        public IActionResult getAllMotorbike()
        {
            var motorbike = _motorbikeService.GetAll();
            return Ok(motorbike);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var motorbike = _motorbikeService.GetById(id);
            return Ok(motorbike);
        }

        [HttpPost("add-motorbike")]
        public IActionResult Create(MotorbikeRequest motorbikeRequest)
        {
            if (ModelState.IsValid)
            {
                _motorbikeService.Create(motorbikeRequest);
                return Ok(motorbikeRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));

        }

        [HttpPut("update-infomation/{id}")]
        public IActionResult Update(int id, MotorbikeRequest motorbikeRequest)
        {
            if (ModelState.IsValid)
            {
                _motorbikeService.Update(id, motorbikeRequest);
                return Ok(motorbikeRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _motorbikeService.Delete(id);
            return Ok(id);
        }

    }
}
