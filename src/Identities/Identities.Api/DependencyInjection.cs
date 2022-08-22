using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Identities.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentities(this IServiceCollection services, 
        IMediatorRegistrationConfigurator mediatorRegistrationConfigurator, IdentitiesApiSettings identitiesApiSettings)
    {
        mediatorRegistrationConfigurator.AddConsumers(Assembly.Load("Identities.Application"));
        
        
        return services;
    }
}