using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ProjectDbContext _dbContext;

        public OrdersController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<OrderResponse>> GetOrders()
        {
            var orders = _dbContext.Orders.ToList();
            var orderResponses = orders.Select(order => MapToOrderResponse(order)).ToList();
            return Ok(orderResponses);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderResponse = MapToOrderResponse(order);
            return Ok(orderResponse);
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<OrderResponse> PostOrder(CreateOrderDto createOrderDto)
        {
            var order = MapToOrder(createOrderDto);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            var orderResponse = MapToOrderResponse(order);
            return CreatedAtAction(nameof(GetOrder), new { id = orderResponse.OrderID }, orderResponse);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Update order properties
            order.UserID = updateOrderDto.UserID;
            order.EventID = updateOrderDto.EventID;
            order.TicketID = updateOrderDto.TicketID;
            order.Quantity = updateOrderDto.Quantity;
            order.TotalPrice = updateOrderDto.TotalPrice;
            order.OrderDate = updateOrderDto.OrderDate;

            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // Helper method to map CreateOrderDto to Order entity
        private Order MapToOrder(CreateOrderDto createOrderDto)
        {
            return new Order
            {
                UserID = createOrderDto.UserID,
                EventID = createOrderDto.EventID,
                TicketID = createOrderDto.TicketID,
                Quantity = createOrderDto.Quantity,
                TotalPrice = createOrderDto.TotalPrice,
                OrderDate = createOrderDto.OrderDate
            };
        }

        // Helper method to map Order entity to OrderResponse DTO
        private OrderResponse MapToOrderResponse(Order order)
        {
            return new OrderResponse
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                EventID = order.EventID,
                TicketID = order.TicketID,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate
            };
        }
    }
}
