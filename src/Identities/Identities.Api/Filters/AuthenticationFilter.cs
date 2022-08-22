using Identities.Application.Services;
using MassTransit;

namespace Identities.Api.Filters;

public class AuthenticationFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
    private readonly ISecurityService _securityService;

    public AuthenticationFilter(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    public void Probe(ProbeContext context)
    {

    }

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        context.Headers.TryGetHeader("identity-id", out var identityId);

        if (identityId != null)
        {
            var id = Guid.Parse((string)identityId);

            _securityService.Context = new IdentityContext(id);
        }

        await next.Send(context);
    }
}