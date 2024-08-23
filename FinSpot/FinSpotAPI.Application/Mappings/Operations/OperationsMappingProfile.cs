using AutoMapper;
using ApplicationModels = FinSpotAPI.Application.Models.Operations;
using DomainModels = FinSpotAPI.Domain.Models.Operations;

namespace FinSpotAPI.Application.Mappings.Operations
{
    public class OperationsMappingProfile : Profile
    {
        public OperationsMappingProfile()
        {
            CreateMap<ApplicationModels.OperationCreateModel, DomainModels.Operation>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => default(int)))
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
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

            CreateMap<DomainModels.Operation, ApplicationModels.OperationModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => default(int)))
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
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
