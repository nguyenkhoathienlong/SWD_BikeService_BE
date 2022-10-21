using AutoMapper;
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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailsService, IMapper mapper)
        {
            _orderDetailService = orderDetailsService;
            _mapper = mapper;
        }

        [HttpGet("get-all-orderdetails")]
        public IActionResult getAllOrderDetail()
        {
            var orderDetails = _orderDetailService.GetAll();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orderDetails = _orderDetailService.GetById(id);
            return Ok(orderDetails);
        }

        [HttpPost]
        public IActionResult Create(OrderDetailsRequest orderDetailsRequest)
        {
            _orderDetailService.Create(orderDetailsRequest);
            return Ok(orderDetailsRequest);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderDetailsRequest orderDetailsRequest)
        {
            _orderDetailService.Update(id, orderDetailsRequest);
            return Ok(orderDetailsRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderDetailService.Delete(id);
            return Ok(id);
        }
    }
}
