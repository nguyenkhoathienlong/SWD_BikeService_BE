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
            var store = _storeService.GetAll();
            return Ok(store);
        }

        [HttpGet("search-Store/{name}")]
        public IActionResult searchByName(string name)
        {
            if (ModelState.IsValid)
            {
                var store = _storeService.GetByName(name);
                return Ok(store);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var store = _storeService.GetById(id);
            return Ok(store);
        }

        [HttpPost]
        public IActionResult Create(StoreRequest storeRequest)
        {
            if (ModelState.IsValid)
            {
                _storeService.Create(storeRequest);
                return Ok(storeRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StoreRequest storeRequest)
        {
            if (ModelState.IsValid)
            {
                _storeService.Update(id, storeRequest);
                return Ok(storeRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _storeService.Delete(id);
            return Ok(id);
        }
    }
}
