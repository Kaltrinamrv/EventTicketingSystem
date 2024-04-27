using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.IServices;
using AutoMapper;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost] //funksionon
        public IActionResult CreateOrder(CreateOrderDto orderDto)
        {
            var createdOrder = _orderService.CreateOrder(orderDto);
            var response = _mapper.Map<OrderResponse>(createdOrder);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = response.OrderID }, response);
        }

        [HttpGet] //funksionon
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            var response = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return Ok(response);
        }

        [HttpGet("{orderId}")] //funksionon
        public IActionResult GetOrderById(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            if (order == null)
                return NotFound();

            var response = _mapper.Map<OrderResponse>(order);
            return Ok(response);
        }

        [HttpPut("{orderId}")] //funksionon
        public IActionResult UpdateOrder(int orderId, UpdateOrderDto orderDto)
        {
            try
            {
                var updatedOrder = _orderService.UpdateOrder(orderId, orderDto);
                var response = _mapper.Map<OrderResponse>(updatedOrder);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{orderId}")] //funksiono
        public IActionResult DeleteOrder(int orderId)
        {
            var isDeleted = _orderService.DeleteOrder(orderId);
            if (!isDeleted)
                return NotFound();

            return Ok("Deleted successfully!");
        }
    }
}
