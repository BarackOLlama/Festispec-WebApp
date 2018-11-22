using AutoMapper;
using Festispec_WebApp.DataTransferObjects;
using Festispec_WebApp.Entities;

namespace Festispec_WebApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}