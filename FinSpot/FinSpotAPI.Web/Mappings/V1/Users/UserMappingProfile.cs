using AutoMapper;
using ApplicationModels = FinSpotAPI.Application.Models.UserService;
using WebModels = FinSpotAPI.Web.Models.V1.Users.Inbound;

namespace FinSpotAPI.Web.Mappings.V1.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<WebModels.UserSignUpModel, ApplicationModels.UserSignUpModel>()
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
                    dest => dest.Password,
                    opt => opt.MapFrom(src => src.Password))
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
