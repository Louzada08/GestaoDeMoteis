using AutoMapper;
using GestaoMotel.Application.Commands.Categorys.Requests;
using GestaoMotel.Application.Commands.Categorys.Responses;
using GestaoMotel.Domain.Entities;

namespace ArqLimpaDDD.Mapping.AutoMapperProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CreateCategoryRequest>()
            .ReverseMap();
        CreateMap<Category, CreateCategoryResponse>().ReverseMap();
    }
}
