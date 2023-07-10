using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data.Dtos;
using UserAPI.Models;

namespace UserAPI.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}
