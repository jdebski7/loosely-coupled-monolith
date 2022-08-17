using Identities.Contract.Commands.Identities;
using MassTransit;

namespace Identities.Application.CommandConsumers;

public class LoginIdentityCommandConsumer : IConsumer<LoginIdentityCommand>
{
    public Task Consume(ConsumeContext<LoginIdentityCommand> context)
    {
        throw new NotImplementedException();
    }
}