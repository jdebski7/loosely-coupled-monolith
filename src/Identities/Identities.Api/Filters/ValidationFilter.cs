using Common.Exceptions;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Identities.Api.Filters;

public class ValidationFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
    public void Probe(ProbeContext context)
    {

    }

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        var serviceProvider = context.GetPayload<IServiceProvider>();

        var validators = serviceProvider.GetServices<IValidator<T>>();
        var validationContext = new ValidationContext<T>(context.Message);

        var errors = validators
            .Select(v => v.Validate(validationContext))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(err => new ValidationError(errorMessage: err.ErrorMessage, propertyName: err.PropertyName))
            .ToList();

        if (errors.Count != 0)
        {
            throw new Common.Exceptions.ValidationException(errors);
        }

        await next.Send(context);
    }
}