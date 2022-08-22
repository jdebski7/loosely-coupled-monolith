using Common.Settings;
using Common.Types;
using FluentValidation;

#pragma warning disable CS8618

namespace Identities.Api;

public class IdentitiesApiSettings : IValidatable
{
    public CosmosDbSettings CosmosDbSettings { get; set; }

    public void Validate()
    {
        new IdentitiesApiSettingsValidator().ValidateAndThrow(this);
        CosmosDbSettings.Validate();
    }
}

internal class IdentitiesApiSettingsValidator : AbstractValidator<IdentitiesApiSettings>
{
    public IdentitiesApiSettingsValidator()
    {
        RuleFor(s => s.CosmosDbSettings).NotNull();
    }
}