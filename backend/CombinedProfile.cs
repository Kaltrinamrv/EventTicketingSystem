
    using AutoMapper;
    using backend.Entities;
    using backend.Models;
  

    namespace backend
    {
        public class CombinedProfile : Profile
        {
            public CombinedProfile()
            {
                // User Profile Mappings
                CreateMap<CreateUserDto, User>();
                CreateMap<UpdateUserDto, User>();
                CreateMap<User, UserResponse>();
                CreateMap<User, UserResponse>();

                // Ticket Profile Mappings
                CreateMap<CreateTicketDto, Ticket>().ReverseMap();
                CreateMap<UpdateTicketDto, Ticket>();
                CreateMap<Ticket, TicketResponse>();

            // Payment Profile Mappings
                 CreateMap<PaymentProcessDto, Payment>().ReverseMap();
                 CreateMap<Payment, PaymentResponseDto>();

                // Order Profile Mappings
                CreateMap<CreateOrderDto, Order>();
                CreateMap<UpdateOrderDto, Order>();
                CreateMap<Order, OrderResponse>();

                // Event Profile Mappings
                CreateMap<CreateEventDto, Event>();
                CreateMap<UpdateEventDto, Event>();
                CreateMap<Event, EventResponse>();
            }
        }
    }

