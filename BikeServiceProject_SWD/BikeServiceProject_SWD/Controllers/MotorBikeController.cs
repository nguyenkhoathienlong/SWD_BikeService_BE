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
