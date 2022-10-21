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
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICustomerService _customerService;


        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("get-all-customer")]
        public IActionResult getAllCustomer()
        {
            var Customer = _customerService.GetAll();
            return Ok(Customer);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Customer = _customerService.GetById(id);
            return Ok(Customer);
        }

        [HttpPost("add-customer")]
        public IActionResult Create(CustomerRequest customerService)
        {
            if (ModelState.IsValid)
            {
                _customerService.Create(customerService);
                return Ok(customerService);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("update-customer-infomation/{id}")]
        public IActionResult Update(int id, CustomerRequest customerService)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(id, customerService);
                return Ok(customerService);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return Ok(id);
        }
    }
}
