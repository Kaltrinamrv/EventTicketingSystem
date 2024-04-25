using backend.Models;
using System.Collections.Generic;

namespace backend.IServices
{
    public interface IOrderService
    {
        OrderResponse CreateOrder(CreateOrderDto orderDto);
        IEnumerable<OrderResponse> GetAllOrders();
        OrderResponse GetOrderById(int orderId);
        OrderResponse UpdateOrder(int orderId, UpdateOrderDto orderDto);
        bool DeleteOrder(int orderId);

    }
}
