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
            _areaService.Create(areaRequest);
            return Ok(areaRequest);

        }

        [HttpPut("/update-area/{id}")]
        public IActionResult Update(int id, AreaRequest areaRequest)
        {
            _areaService.Update(id, areaRequest);
            return Ok(areaRequest);
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
            _wardService.Create(wardRequest);
            return Ok(wardRequest);

        }

        [HttpPut("/update-ward/{id}")]
        public IActionResult Update(int id, WardRequest wardRequest)
        {
            _wardService.Update(id, wardRequest);
            return Ok(wardRequest);
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
            _districtService.Create(districtRequest);
            return Ok(districtRequest);

        }

        [HttpPut("/update-district/{id}")]
        public IActionResult Update(int id, DistrictRequest districtRequest)
        {
            _districtService.Update(id, districtRequest);
            return Ok(districtRequest);
        }

        [HttpDelete("/district/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            _districtService.Delete(id);
            return Ok(id);
        }
    }
}
