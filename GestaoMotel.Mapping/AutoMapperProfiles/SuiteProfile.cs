using AutoMapper;
using GestaoMotel.Application.Commands.Suites.Requests;
using GestaoMotel.Application.Commands.Suites.Responses;
using GestaoMotel.Domain.Entities;

namespace ArqLimpaDDD.Mapping.AutoMapperProfiles;

public class SuiteProfile : Profile
{
    public SuiteProfile()
    {
        CreateMap<Suite, CreateSuiteRequest>().ReverseMap();
        CreateMap<Suite, CreateSuiteResponse>().ReverseMap();
    }
}
