using AutoMapper;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IStoreService _storeService;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet("get-all-store")]
        public IActionResult getAllStore()
        {
            var Store = _storeService.GetAll();
            return Ok(Store);
        }

        //[HttpGet("search-Store/{name}")]
        //public IActionResult searchByName(string name)
        //{
        //    var Store = _storeService.GetByName(name);
        //    return Ok(Store);
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Store = _storeService.GetById(id);
            return Ok(Store);
        }

        [HttpPost]
        public IActionResult Create(StoreRequest storeRequest)
        {
            _storeService.Create(storeRequest);
            return Ok(storeRequest);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StoreRequest storeRequest)
        {
            _storeService.Update(id, storeRequest);
            return Ok(storeRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _storeService.Delete(id);
            return Ok(id);
        }
    }
}
