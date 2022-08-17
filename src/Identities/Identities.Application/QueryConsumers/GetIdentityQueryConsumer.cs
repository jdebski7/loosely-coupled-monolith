using Identities.Contract.Queries.Identities;
using MassTransit;

namespace Identities.Application.QueryConsumers;

public class GetIdentityQueryConsumer : IConsumer<GetIdentityQuery>
{
    public Task Consume(ConsumeContext<GetIdentityQuery> context)
    {
        throw new NotImplementedException();
    }
}