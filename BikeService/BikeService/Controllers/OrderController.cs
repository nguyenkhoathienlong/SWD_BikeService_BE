using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            _orderService.Create(orderRequest);
            return Ok(orderRequest);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderRequest orderRequest)
        {
            _orderService.Update(id, orderRequest);
            return Ok(orderRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok(id);
        }
    }
}
