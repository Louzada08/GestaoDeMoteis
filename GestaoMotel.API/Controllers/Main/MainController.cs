using AutoMapper;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GestaoMotel.API.Controllers.Main
{
    [ApiController]
    public class MainController : Controller
    {
        protected ICollection<string> _errors = new List<string>();
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public MainController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
               { "Mensagens", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors);

            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }
            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResultBag validationResultBag)
        {
            if(validationResultBag.Errors.Count > 0)
            {
                var erros = validationResultBag.Errors.Select(e => e.ErrorMessage).ToList();
                foreach (var error in erros)
                    AddError(error);
            }
 
            return CustomResponse(validationResultBag.Data);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErros()
        {
            _errors.Clear();
        }

    }
}
