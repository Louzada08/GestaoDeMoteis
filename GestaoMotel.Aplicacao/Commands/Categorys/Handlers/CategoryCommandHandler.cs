using AutoMapper;
using GestaoMotel.Application.Commands.Categorys.Requests;
using GestaoMotel.Application.Commands.Categorys.Responses;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.Validation;
using MediatR;

namespace GestaoMotel.Application.Commands.Categorys.Handlers;

public class CategoryCommandHandler : CommandHandler,
    IRequestHandler<CreateCategoryRequest, ValidationResultBag>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryService _categoryService;

    public CategoryCommandHandler(IMapper mapper, ICategoryService categoryService, 
        ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryService = categoryService;
        _categoryRepository = categoryRepository;
    }

    public async Task<ValidationResultBag> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var category = _mapper.Map<Category>(request);

        var ret = await _categoryService.Create(category);

        ValidationResult.Data = _mapper.Map<CreateCategoryResponse>(ret);
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