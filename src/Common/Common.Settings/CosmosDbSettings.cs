using Common.Types;
using FluentValidation;

namespace Common.Settings;

#pragma warning disable CS8618

public class CosmosDbSettings : IValidatable
{
    public string ConnectionString { get; set; }

    public void Validate()
    {
        new CosmosDbSettingsValidator().ValidateAndThrow(this);
    }
}

internal class CosmosDbSettingsValidator : AbstractValidator<CosmosDbSettings>
{
    public CosmosDbSettingsValidator()
    {
        RuleFor(s => s.ConnectionString).NotEmpty();
    }
}