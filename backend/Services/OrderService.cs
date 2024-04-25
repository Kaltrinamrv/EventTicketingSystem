using AutoMapper;
using backend.DataAccess;
using backend.Entities;
using backend.IServices;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly ProjectDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, ProjectDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public OrderResponse CreateOrder(CreateOrderDto orderDto)
        {
            var newOrder = _mapper.Map<Order>(orderDto);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return _mapper.Map<OrderResponse>(newOrder);
        }

        public IEnumerable<OrderResponse> GetAllOrders()
        {
            var orders = _context.Orders.ToList();
            return _mapper.Map<IEnumerable<OrderResponse>>(orders);
        }

        public OrderResponse GetOrderById(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            return _mapper.Map<OrderResponse>(order);
        }

        public OrderResponse UpdateOrder(int orderId, UpdateOrderDto orderDto)
        {
            var orderToUpdate = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (orderToUpdate == null)
                throw new ApplicationException("Order not found.");

            _mapper.Map(orderDto, orderToUpdate);
            _context.SaveChanges();

            return _mapper.Map<OrderResponse>(orderToUpdate);
        }

        public bool DeleteOrder(int orderId)
        {
            var orderToDelete = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (orderToDelete == null)
                return false;

            _context.Orders.Remove(orderToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
