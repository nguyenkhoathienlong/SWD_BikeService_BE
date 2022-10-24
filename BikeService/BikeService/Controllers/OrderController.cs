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
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IOrderService _orderService;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("get-all-order")]
        public IActionResult getAllOrder()
        {
            var order = _orderService.GetAll();
            return Ok(order);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(OrderRequest orderRequest)
        {
            if (ModelState.IsValid)
            {
                _orderService.Create(orderRequest);
                return Ok(orderRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderRequest orderRequest)
        {
            if (ModelState.IsValid)
            {
                _orderService.Update(id, orderRequest);
                return Ok(orderRequest);
            }
            return Ok(new ThrowingException("Please double check the data!!!"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok(id);
        }
    }
}
