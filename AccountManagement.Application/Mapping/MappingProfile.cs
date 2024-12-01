using AccountManagement.Application.DTOs;
using AccountManagement.Domain.Entities;
using AutoMapper;

namespace AccountManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MailUserCreateDto, User>();
            CreateMap<MobileUserCreateDto, User>();
            CreateMap<WebUserCreateDto, User>();
        }
    }
}
