using AutoMapper;
using FluentValidation.Results;
using GestaoMotel.API.Controllers.Main;
using GestaoMotel.Application.Commands.Categorys.Requests;
using GestaoMotel.Application.Commands.Categorys.Responses;
using GestaoMotel.Domain.Filters;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GestaoMotel.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : MainController
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service, IMediator mediator, IMapper mapper) : 
        base(mediator, mapper)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByAll([FromQuery] CategoryFilter categoryFilter)
    {
        var response = await _service.GetAll(categoryFilter);

        if (response is not null) return CustomResponse(response);

        var bag = new ValidationResultBag();
        bag.Errors.Add(new ValidationFailure("error", "Nenhum registro encontrado"));
        return CustomResponse(bag);
    }

    [HttpGet("{id}")]
    public string GetById(Guid id)
    {
        return "value";
    }

    [HttpPost]
    //[Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(CreateCategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest command)
    {
        var response = await _mediator.Send(command);

        if (response is not null) return CustomResponse(response);

        var bag = new ValidationResultBag();
        bag.Errors.Add(new ValidationFailure("error", "Não foi possível salvar"));
        return CustomResponse(bag);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
