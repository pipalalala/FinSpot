using AutoMapper;
using WebModels = FinSpotAPI.Web.Models.V1.Operations;
using ApplicationModels = FinSpotAPI.Application.Models.Operations;

namespace FinSpotAPI.Web.Mappings.V1.Operations
{
    public class OperationsMappingProfile : Profile
    {
        public OperationsMappingProfile()
        {
            CreateMap<WebModels.Inbound.OperationCreateModel, ApplicationModels.OperationCreateModel>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.DateTime))
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Amount))
                .ForMember(
                    dest => dest.Currency,
                    opt => opt.MapFrom(src => src.Currency))
                .ForMember(
                    dest => dest.ExpenseCategory,
                    opt => opt.MapFrom(src => src.ExpenseCategory))
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => src.Details));

            CreateMap<WebModels.Inbound.OperationUpdateModel, ApplicationModels.OperationUpdateModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.DateTime))
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Amount))
                .ForMember(
                    dest => dest.Currency,
                    opt => opt.MapFrom(src => src.Currency))
                .ForMember(
                    dest => dest.ExpenseCategory,
                    opt => opt.MapFrom(src => src.ExpenseCategory))
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => src.Details));

            CreateMap<ApplicationModels.OperationModel, WebModels.Outbound.OperationModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.DateTime))
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Amount))
                .ForMember(
                    dest => dest.Currency,
                    opt => opt.MapFrom(src => src.Currency))
                .ForMember(
                    dest => dest.ExpenseCategory,
                    opt => opt.MapFrom(src => src.ExpenseCategory))
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => src.Details));
        }
    }
}
