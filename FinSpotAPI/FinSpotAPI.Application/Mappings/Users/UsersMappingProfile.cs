using AutoMapper;
using FinSpotAPI.Common.Enumerations;
using FinSpotAPI.Common.Helpers;
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
                    dest => dest.Email,
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
                    opt => opt.MapFrom(src =>
                        src.Gender == Gender.Custom
                            ? src.GenderName
                            : src.Gender.GetDescription()))
                .AfterMap<PasswordHashingAction>();

            CreateMap<DomainModels.User, ApplicationModels.UserModel>()
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
                    opt => opt.MapFrom(src => src.GenderName));
        }
    }
}
