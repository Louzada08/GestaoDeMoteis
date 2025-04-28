using AutoMapper;
using FluentValidation.Results;
using GestaoMotel.Application.Commands.Suites.Requests;
using GestaoMotel.Application.Commands.Suites.Responses;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestaoMotel.Application.Commands.Suites.Handlers;

public class SuiteCommandHandler : CommandHandler,
    IRequestHandler<CreateSuiteRequest, ValidationResultBag>
{
    private readonly IMapper _mapper;
    private readonly ISuiteService _suiteService;
    private readonly ISuiteRepository _suiteRepository;
    private readonly ICategoryRepository _categoryRepository;

    public SuiteCommandHandler(IMapper mapper, ISuiteService suiteService, 
        ISuiteRepository suiteRepository, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _suiteService = suiteService;
        _suiteRepository = suiteRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ValidationResultBag> Handle(CreateSuiteRequest request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }
        var categoria = await _categoryRepository.QueryableFor(g => g.Id.Equals(request.CategoryId))
            .FirstOrDefaultAsync();

        if (categoria == null)
        {
            ValidationResult.Errors.Add(new ValidationFailure("Error 404", "Categoria da Suíte não encontrado"));
            return ValidationResult;
        }

        request.CategoryId = categoria.Id;

        var suite = _mapper.Map<Suite>(request);

        var ret = await _suiteService.Create(suite);

        ValidationResult.Data = _mapper.Map<CreateSuiteResponse>(ret);
        return ValidationResult;
    }

    //public async Task<ValidationResultBag> Handle(PatchPaymentRequest request, CancellationToken cancellationToken)
    //{
    //    if (!request.IsValid())
    //    {
    //        ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
    //        return ValidationResult;
    //    }

    //    Payment? pay = _paymentRepository.FindById(request.Id);

    //    if (pay is null)
    //    {
    //        ValidationResult.Errors.Add(new ValidationFailure("Error", "Dados do Pagamento não encontrado"));
    //        return ValidationResult;
    //    }

    //    var patchPayment = _mapper.Map<PatchPaymentRequest>(pay);
    //    request.PatchPayment.ApplyTo(patchPayment);

    //    _mapper.Map(patchPayment, pay);

    //    var ret = _paymentRepository.Update(pay);
    //    await PersistData(_paymentRepository.UnitOfWork);

    //    ValidationResult.Data = _mapper.Map<GetPaymentResponse>(ret);
    //    return ValidationResult;
    //}
}