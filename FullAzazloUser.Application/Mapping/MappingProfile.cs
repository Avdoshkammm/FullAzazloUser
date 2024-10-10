using AutoMapper;
using FullAzazloUser.Application.DTOs;
using FullAzazloUser.Domain.Entities;

namespace FullAzazloUser.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
