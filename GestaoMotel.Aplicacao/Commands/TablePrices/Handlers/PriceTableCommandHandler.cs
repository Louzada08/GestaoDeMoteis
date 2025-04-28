using AutoMapper;
using FluentValidation.Results;
using GestaoMotel.Application.Commands.Categorys.Responses;
using GestaoMotel.Application.Commands.TablePrices.Requests;
using GestaoMotel.Application.Commands.TablePrices.Validations;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestaoMotel.Application.Commands.TablePrices.Handlers;

public class PriceTableCommandHandler : CommandHandler,
    IRequestHandler<CreatePriceTableRequest, ValidationResultBag>,
    IRequestHandler<CreatePriceTableTimeRequest, ValidationResultBag>
{
    private readonly IMapper _mapper;
    private readonly IPriceTableService _priceTableService;
    private readonly IPriceTableTimeService _priceTableTimeService;
    private readonly IPriceTableTimeRepository _priceTableTimeRepository;
    private readonly IPriceTableRepository _priceTableRepository;
    private readonly ICategoryRepository _categoryRepository; 

    public PriceTableCommandHandler(IMapper mapper, IPriceTableService priceTableService,
        IPriceTableTimeRepository priceTableTimeRepository, IPriceTableRepository priceTableRepository, 
        IPriceTableTimeService priceTableTime, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _priceTableService = priceTableService;
        _priceTableTimeService = priceTableTime;
        _priceTableTimeRepository = priceTableTimeRepository;
        _priceTableRepository = priceTableRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ValidationResultBag> Handle(CreatePriceTableRequest request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var category = await _categoryRepository.QueryableFor(c => c.Id.Equals(request.CategoryId))
            .FirstOrDefaultAsync();
        if (category is null)
        {
            ValidationResult.Errors.Add(new ValidationFailure("Error 404", "Categoria da Suíte não encontrado"));
            return ValidationResult;
        }

        request.AssignCategoryId(category.Id);

        var price = _mapper.Map<PriceTable>(request);

        var ret = await _priceTableService.Create(price);

        ValidationResult.Data = _mapper.Map<CreatePriceTableResponse>(ret);
        return ValidationResult;
    }

    public async Task<ValidationResultBag> Handle(CreatePriceTableTimeRequest request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var priceTable = await _priceTableRepository.QueryableFor(r => r.Id.Equals(request.PriceTableId))
                .FirstOrDefaultAsync();

        if (priceTable is null)
        {
            ValidationResult.Errors.Add(new ValidationFailure("Error", "Tabela de preço não encontrado"));
            return ValidationResult;
        }

        var priceTableTime = await _priceTableTimeRepository.QueryableFor(r => r.PriceTableId.Equals(request.PriceTableId) && r.RuleOrder.Equals(request.RuleOrder))
                .FirstOrDefaultAsync();

        if (priceTableTime is not null)
        {
            ValidationResult.Errors.Add(new ValidationFailure("Error", "Tabela de preço já registrada"));
            return ValidationResult;
        }

        request.PriceTableId = priceTable.Id;

        var pricesTime = _mapper.Map<PriceTableTime>(request);

        var ret = await _priceTableTimeService.Create(pricesTime);

        ValidationResult.Data = _mapper.Map<CreatePriceTableTimeResponse>(ret);
        return ValidationResult;
    }
}