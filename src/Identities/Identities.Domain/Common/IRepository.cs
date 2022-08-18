namespace Identities.Domain.Common;

public interface IRepository<TAggregate> where TAggregate : Entity, IAggregate
{
}