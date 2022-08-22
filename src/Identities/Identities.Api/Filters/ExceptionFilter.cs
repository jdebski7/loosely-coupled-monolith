using Common.Exceptions;
using Common.Types.Responses;
using MassTransit;

namespace Identities.Api.Filters;

public class ExceptionFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
    public void Probe(ProbeContext context)
    {

    }

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        try
        {
            await next.Send(context);
        }
        catch (Common.Exceptions.ApplicationException applicationException)
        {
            var errorViewModel = applicationException switch
            {
                BusinessLogicException e => new ErrorResponse(
                    type: ErrorType.Authentication,
                    message: e.Message),
                ValidationException e => new ErrorResponse(
                    type: ErrorType.Validation,
                    message: "" // TODO: Remove
                    // validationErrors: e.Errors.Select(ee =>
                    //     new ValidationError(ee.PropertyName, ee.ErrorMessage))
                    ),
                AuthenticationException e => new ErrorResponse(
                    type: ErrorType.Authentication,
                    message: e.Message),
                AuthorizationException e => new ErrorResponse(
                    type: ErrorType.Authorization,
                    message: e.Message),
                NotFoundException e => new ErrorResponse(
                    type: ErrorType.NotFound,
                    message: e.Message),
            };

            await context.RespondAsync(errorViewModel);
        }
    }
}