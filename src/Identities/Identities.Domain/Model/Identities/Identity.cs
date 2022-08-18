using Identities.Domain.Common;
using NodaTime;

namespace Identities.Domain.Model.Identities;

public class Identity : Entity, IAggregate
{
    public Guid Id { get; private init; }
    public string Email { get; private init; }
    public string FullName { get; private init; }
    public string PasswordHash { get; private init; }
    public Instant RegisteredAt { get; private init; }

    // needed by EF
    private Identity()
    {
    }

    public static Identity Register(string email, string fullName, string password)
    {
        var identity = new Identity()
        {
            Id = Guid.NewGuid(),
            Email = email.ToLower(),
            FullName = fullName,
            PasswordHash = PasswordHasher.Hash(password),
            RegisteredAt = Clock.Now
        };

        return identity;
    }

    public bool Authenticate(string password)
    {
        return PasswordHasher.Verify(password, PasswordHash);
    }
}