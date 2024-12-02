using AccountManagement.Application.DTOs;
using AccountManagement.Domain.Entities;
using AutoMapper;

namespace AccountManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDto, MailUserCreateDto>();
            CreateMap<UserCreateDto, MobileUserCreateDto>();
            CreateMap<UserCreateDto, WebUserCreateDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
