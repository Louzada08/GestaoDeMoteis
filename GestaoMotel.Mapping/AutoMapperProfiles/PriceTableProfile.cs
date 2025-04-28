using AutoMapper;
using GestaoMotel.Application.Commands.Categorys.Responses;
using GestaoMotel.Application.Commands.TablePrices.Requests;
using GestaoMotel.Domain.Dtos;
using GestaoMotel.Domain.Entities;

namespace ArqLimpaDDD.Mapping.AutoMapperProfiles;

public class PriceTableProfile : Profile
{
    public PriceTableProfile()
    {
        CreateMap<PriceTable, CreatePriceTableRequest>().ReverseMap();
        CreateMap<PriceTable, CreatePriceTableResponse>().ReverseMap();
        CreateMap<PriceTable, PriceTableDTO>()
            .ForMember(d => d.PriceTableTimesDTO, o => o.MapFrom(o => o.PriceTableTimes))
            .ReverseMap();
        CreateMap<PriceTableTime, PriceTableTimeDTO>().ReverseMap();
    }
}
