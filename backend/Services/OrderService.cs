using backend.Models;
using System.Collections.Generic;
using System.Linq;
using backend.Entities;

namespace backend.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>(); 
        }

        // Create a new order
        public OrderResponse CreateOrder(CreateOrderDto orderDto)
        {
            var newOrder = new Order
            {
                UserID = orderDto.UserID,
                EventID = orderDto.EventID,
                TicketID = orderDto.TicketID,
                Quantity = orderDto.Quantity,
                TotalPrice = orderDto.TotalPrice,
                OrderDate = orderDto.OrderDate
            };

            _orders.Add(newOrder);

            return MapOrderToOrderResponse(newOrder);
        }

        public IEnumerable<OrderResponse> GetAllOrders()
        { 
            return _orders.Select(o => MapOrderToOrderResponse(o));
        }

        public OrderResponse GetOrderById(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
                return null; 

            return MapOrderToOrderResponse(order);
        }

        // Update an order
        public OrderResponse UpdateOrder(int orderId, UpdateOrderDto orderDto)
        {
            var orderToUpdate = _orders.FirstOrDefault(o => o.OrderID == orderId);
            if (orderToUpdate == null)
                return null;

            orderToUpdate.UserID = orderDto.UserID;
            orderToUpdate.EventID = orderDto.EventID;
            orderToUpdate.TicketID = orderDto.TicketID;
            orderToUpdate.Quantity = orderDto.Quantity;
            orderToUpdate.TotalPrice = orderDto.TotalPrice;
            orderToUpdate.OrderDate = orderDto.OrderDate;

            return MapOrderToOrderResponse(orderToUpdate);
        }

        // Delete an order
        public bool DeleteOrder(int orderId)
        {
            var orderToDelete = _orders.FirstOrDefault(o => o.OrderID == orderId);
            if (orderToDelete == null)
                return false; 

            _orders.Remove(orderToDelete); 
            return true;
        }

        private OrderResponse MapOrderToOrderResponse(Order order)
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
