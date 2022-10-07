using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iLearning.Listography.API.Common.FilterAttributes;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(NotFoundException), HandleNotFoundException }
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        var response = new ErrorResponse()
        {
            Succeeded = false,
            Errors = new string[] { context.Exception.Message }
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var response = new ErrorResponse()
        {
            Succeeded = false,
            Errors = new string[] { 
                "An error occured while processing request.",
                context.Exception.Message
            }
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
