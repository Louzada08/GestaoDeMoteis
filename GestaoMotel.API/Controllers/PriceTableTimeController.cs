//using AutoMapper;
//using FluentValidation.Results;
//using GestaoMotel.API.Controllers.Main;
//using GestaoMotel.Application.Commands.Categorys.Responses;
//using GestaoMotel.Application.Commands.TablePrices.Requests;
//using GestaoMotel.Application.Commands.TablePrices.Validations;
//using GestaoMotel.Domain.Filters;
//using GestaoMotel.Domain.Interfaces.Repositories;
//using GestaoMotel.Domain.Interfaces.Services;
//using GestaoMotel.Domain.Validation;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;


//namespace GestaoMotel.API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class PriceTableTimeController : MainController
//{
//    private readonly IPriceTableService _service;
//    private readonly IPriceTableTimeService _serviceTime;
//    private readonly ICategoryRepository _categoryRepository;

//    public PriceTableTimeController(IPriceTableService service, IPriceTableTimeService priceTableTime,
//        ICategoryRepository categoryRepository, IMediator mediator, IMapper mapper) : 
//        base(mediator, mapper)
//    {
//        _service = service;
//        _serviceTime = priceTableTime;
//        _categoryRepository = categoryRepository;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetByAll([FromQuery] PriceTableFilter query)
//    {
//        try
//        {
//            var pricesTable = await _service.GetAll(query);
//            return CustomResponse(pricesTable);
//        }
//        catch (Exception ex)
//        {
//            return CustomResponse(StatusCodes.Status400BadRequest);
//        }
//    }


//    [HttpPost]
//    //[Authorize(Policy = "Loja")]
//    [ProducesResponseType(typeof(CreatePriceTableTimeResponse), StatusCodes.Status201Created)]
//    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
//    public async Task<IActionResult> CreateItem([FromBody] CreatePriceTableTimeRequest command)
//    {
//        var response = await _mediator.Send(command);

//        if (response is not null) //return CustomResponse(response);
//            return CustomResponse(new { Status = StatusCodes.Status400BadRequest, Error = response.Errors });

//        var bag = new ValidationResultBag();
//        bag.Errors.Add(new ValidationFailure("error", "Não foi possível salvar item de preço"));
//        return CustomResponse(bag);
//    }

//}
