using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoBikeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IMotorbikeService _motorbikeService;

        public MotoBikeController(IMotorbikeService motorbikeService, IMapper mapper)
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
            _motorbikeService.Create(motorbikeRequest);
            return Ok(motorbikeRequest);

        }

        [HttpPut("update-infomation/{id}")]
        public IActionResult Update(int id, MotorbikeRequest motorbikeRequest)
        {
            _motorbikeService.Update(id, motorbikeRequest);
            return Ok(motorbikeRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _motorbikeService.Delete(id);
            return Ok(id);
        }

    }
}
