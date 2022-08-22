using Identities.Api.Filters;
using MassTransit;

namespace Identities.Api.ConfigurationObservers;

public class ExceptionConsumerConfigurationObserver :
    IConsumerConfigurationObserver
{
    public void ConsumerConfigured<TConsumer>(IConsumerConfigurator<TConsumer> configurator)
        where TConsumer : class
    {
    }

    public void ConsumerMessageConfigured<TConsumer, TMessage>(
        IConsumerMessageConfigurator<TConsumer, TMessage> configurator)
        where TConsumer : class
        where TMessage : class
    {
        configurator.Message(x => x.UseFilter(new ExceptionFilter<TMessage>()));
    }
}