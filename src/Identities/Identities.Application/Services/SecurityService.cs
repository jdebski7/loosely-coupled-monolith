using Common.Exceptions;

namespace Identities.Application.Services;

public class IdentityContext
{
    public Guid IdentityId { get; }

    public IdentityContext(Guid identityId)
    {
        IdentityId = identityId;
    }
}

public interface ISecurityService
{
    public IdentityContext? Context { get; set; }
    public IdentityContext RequireContext();
}

internal class SecurityService : ISecurityService
{
    public IdentityContext? Context { get; set; }

    public IdentityContext RequireContext()
    {
        if (Context == null)
        {
            throw new AuthorizationException();
        }

        return Context;
    }
}