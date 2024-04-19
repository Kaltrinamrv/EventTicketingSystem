using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Order/5
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

    }
}

