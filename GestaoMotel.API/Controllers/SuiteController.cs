using AutoMapper;
using FluentValidation.Results;
using GestaoMotel.API.Controllers.Main;
using GestaoMotel.Application.Commands.Suites.Requests;
using GestaoMotel.Application.Commands.Suites.Responses;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GestaoMotel.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuiteController : MainController
{
    private readonly ISuiteService _service;

    public SuiteController(ISuiteService service, IMediator mediator, IMapper mapper) : 
        base(mediator, mapper)
    {
        _service = service;
    }

    // GET: api/<SuiteController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<SuiteController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    //[Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(CreateSuiteResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSuiteRequest command)
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
