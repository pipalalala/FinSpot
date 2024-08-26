using AutoMapper;
using FinSpotAPI.Domain.Models.Users;
using FinSpotAPI.Infrastructure.Models;

namespace FinSpotAPI.Infrastructure.Mappings
{
    public class CurrentUserMappingProfile : Profile
    {
        public CurrentUserMappingProfile()
        {
            CreateMap<User, CurrentUser>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}
