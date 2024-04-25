using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profile
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, OrderResponse>();
           
        }
    }
}
