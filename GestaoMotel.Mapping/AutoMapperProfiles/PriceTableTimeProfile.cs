using AutoMapper;
using GestaoMotel.Application.Commands.TablePrices.Requests;
using GestaoMotel.Application.Commands.TablePrices.Validations;
using GestaoMotel.Domain.Entities;

namespace GestaoMotel.Mapping.AutoMapperProfiles;

public class PriceTableTimeProfile : Profile
{
    public PriceTableTimeProfile()
    {
        CreateMap<PriceTableTime, CreatePriceTableTimeRequest>().ReverseMap();
        CreateMap<PriceTableTime, CreatePriceTableTimeResponse>().ReverseMap();
    }
}
