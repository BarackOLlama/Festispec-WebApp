using AutoMapper;
using Festispec_WebApp.DataTransferObjects;
using Festispec_WebApp.Models;

namespace Festispec_WebApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Accounts, UserDto>();
            CreateMap<UserDto, Accounts>();
        }
    }
}