using AutoMapper;
using FluentValidation.Results;
using GestaoMotel.API.Controllers.Main;
using GestaoMotel.Application.Commands.Categorys.Responses;
using GestaoMotel.Application.Commands.TablePrices.Requests;
using GestaoMotel.Application.Commands.TablePrices.Validations;
using GestaoMotel.Domain.DomainServices;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;
using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GestaoMotel.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PriceTableController : MainController
{
    private readonly IPriceTableService _service;
    private readonly IPriceTableTimeService _serviceTime;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICalculatePermanence _permanence;
    private readonly ICommandService _commands;
    private readonly ISubject _subject;

    public PriceTableController(IPriceTableService service, IPriceTableTimeService priceTableTime,
        ICategoryRepository categoryRepository, ICalculatePermanence permanence,ISubject subject,
        ICommandService commands, IMediator mediator, IMapper mapper) : 
        base(mediator, mapper)
    {
        _service = service;
        _serviceTime = priceTableTime;
        _categoryRepository = categoryRepository;
        _permanence = permanence;
        _subject = subject;
        _commands = commands;

        //------------------ Teste Observer
        decimal novoValorHoras = 0; // todo = obter o valor da comanda atual

        var observerA = new ConcreteObserverA();
        subject.Attach(observerA);

        _subject.TempoUso.Stop();
        var observerB = new ConcreteObserverB();
        subject.Attach(observerB);
    }

    [HttpGet]
    public async Task<IActionResult> GetByAll([FromQuery] PriceTableFilter query)
    {
        decimal novoValorHoras = 0; // todo = obter o valor da comanda atual
        var comanda = await _commands.GetAll();

        try
        {
            // var pricesTable = _mapper.Map<List<PriceTableDTO>>(await _service.GetAll(query));
            foreach(ServiceCommand cmd in comanda)
            {
                var pricesTable = await _service.GetAll(cmd);

                foreach (PriceTable table in pricesTable)
                {
                    foreach (PriceTableTime vlrHora in table.PriceTableTimes)
                    {
                        var valorTable = vlrHora.Price;
                        _subject.PrecoNovo = valorTable.Price;
                        _subject.SomeBusinessLogic();
                        _subject.Notify();
                    }
                }
            }

            // var valorHora = await _permanence.GetTable(query);


            return CustomResponse(_subject);
        }
        catch (Exception ex)
        {
            return CustomResponse(StatusCodes.Status400BadRequest);
        }
    }

    [HttpGet("{id}")]
    public string GetById(int id)
    {
        return "value";
    }

    [HttpPost]
    //[Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(CreatePriceTableResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreatePriceTableRequest command)
    {
        var response = await _mediator.Send(command);

        if (response is not null) //return CustomResponse(response);
            return CustomResponse(new { Status = StatusCodes.Status400BadRequest, Error = response.Errors });

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


    [HttpPost("pricesTime")]
    //[Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(CreatePriceTableTimeResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateItem([FromBody] CreatePriceTableTimeRequest command)
    {
        var response = await _mediator.Send(command);

        if (response is not null) return CustomResponse(response);

        var bag = new ValidationResultBag();
        bag.Errors.Add(new ValidationFailure("error", "Não foi possível salvar item de preço"));
        return CustomResponse(bag);
    }

}
