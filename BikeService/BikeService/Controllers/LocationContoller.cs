using AutoMapper;
using BikeService.Helpers;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class LocationContoller : ControllerBase
    {
        private readonly IMapper _mapper;
        private IAreaService _areaService;
        private IWardService _wardService;
        private IDistrictService _districtService;

        public LocationContoller(IAreaService areaService, IMapper mapper, IDistrictService districtService, IWardService wardService)
        {
            _areaService = areaService;
            _mapper = mapper;
            _districtService = districtService;
            _wardService = wardService;
        }

        // Area -----------------------------------------

        [HttpGet("/get-all-area")]
        public IActionResult getAllArea()
        {
            var area = _areaService.GetAll();
            return Ok(area);
        }

        [HttpGet("/area/{id}")]
        public IActionResult GetAreaById(int id)
        {
            var area = _areaService.GetById(id);
            return Ok(area);
        }

        [HttpPost("/add-area")]
        public IActionResult Create(AreaRequest areaRequest)
        {
            if (ModelState.IsValid)
            {
                _areaService.Create(areaRequest);
                return Ok(areaRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("/update-area/{id}")]
        public IActionResult Update(int id, AreaRequest areaRequest)
        {
            if (ModelState.IsValid)
            {
                _areaService.Update(id, areaRequest);
                return Ok(areaRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("/area/{id}")]
        public IActionResult DeleteArea(int id)
        {
            _areaService.Delete(id);
            return Ok(id);
        }

        // Ward -----------------------------------------

        [HttpGet("/get-all-ward")]
        public IActionResult getAllWard()
        {
            var ward = _wardService.GetAll();
            return Ok(ward);
        }

        [HttpGet("/ward/{id}")]
        public IActionResult GetWardById(int id)
        {
            var ward = _wardService.GetById(id);
            return Ok(ward);
        }

        [HttpPost("/add-ward")]
        public IActionResult Create(WardRequest wardRequest)
        {
            if (ModelState.IsValid)
            {
                _wardService.Create(wardRequest);
                return Ok(wardRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("/update-ward/{id}")]
        public IActionResult Update(int id, WardRequest wardRequest)
        {
            if (ModelState.IsValid)
            {
                _wardService.Update(id, wardRequest);
                return Ok(wardRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("/ward/{id}")]
        public IActionResult DeleteWard(int id)
        {
            _wardService.Delete(id);
            return Ok(id);
        }

        // District -----------------------------------------

        [HttpGet("/get-all-district")]
        public IActionResult getAllDistrict()
        {
            var district = _districtService.GetAll();
            return Ok(district);
        }

        [HttpGet("/district/{id}")]
        public IActionResult GetDistrictById(int id)
        {
            var district = _districtService.GetById(id);
            return Ok(district);
        }

        [HttpPost("/add-district")]
        public IActionResult Create(DistrictRequest districtRequest)
        {
            if (ModelState.IsValid)
            {
                _districtService.Create(districtRequest);
                return Ok(districtRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("/update-district/{id}")]
        public IActionResult Update(int id, DistrictRequest districtRequest)
        {
            if (ModelState.IsValid)
            {
                _districtService.Update(id, districtRequest);
                return Ok(districtRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("/district/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            _districtService.Delete(id);
            return Ok(id);
        }
    }
}
