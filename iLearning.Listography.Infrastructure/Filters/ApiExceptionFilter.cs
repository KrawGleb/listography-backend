using FluentValidation;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iLearning.Listography.Infrastructure.Filters;

public class ApiExceptionFilter : IActionFilter, IOrderedFilter
{
    private readonly IDictionary<Type, Action<ActionExecutedContext>> _exceptionHandlers;

    public ApiExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ActionExecutedContext>>
        {
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(ValidationException), HandleValidationException },
            { typeof(UserIsBlockedException), HandlerUserIsBlockedException }
        };
    }

    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is not null)
            HandleException(context);
    }

    private void HandleException(ActionExecutedContext context)
    {
        var type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            context.ExceptionHandled = true;
            return;
        }

        HandleUnknownException(context);
        context.ExceptionHandled = true;
    }

    private void HandleValidationException(ActionExecutedContext context)
    {
        var exception = (ValidationException)context.Exception;
        var errors = exception.Errors.Select(e => e.ErrorMessage);

        var response = new ErrorResponse()
        {
            Succeeded = false,
            Errors = errors
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
    }

    private void HandleNotFoundException(ActionExecutedContext context)
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

    private void HandlerUserIsBlockedException(ActionExecutedContext context)
    {
        var response = new ErrorResponse()
        {
            Succeeded = false,
            Errors = new string[] { context.Exception.Message }
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status403Forbidden
        };
    }

    private void HandleUnknownException(ActionExecutedContext context)
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
