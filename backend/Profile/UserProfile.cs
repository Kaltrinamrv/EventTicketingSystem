using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
