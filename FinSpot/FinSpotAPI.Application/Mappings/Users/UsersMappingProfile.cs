using AutoMapper;
using ApplicationModels = FinSpotAPI.Application.Models.Users;
using DomainModels = FinSpotAPI.Domain.Models.Users;

namespace FinSpotAPI.Application.Mappings.Users
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<ApplicationModels.UserSignUpModel, DomainModels.User>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => default(int)))
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.HashedPassword,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(
                    dest => dest.MobileNumber,
                    opt => opt.MapFrom(src => src.MobileNumber))
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender))
                .ForMember(
                    dest => dest.GenderName,
                    opt => opt.MapFrom(src => src.GenderName))
                .AfterMap<PasswordHashingAction>();
        }
    }
}
