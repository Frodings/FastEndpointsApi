using FastEndpoints;
using FluentValidation;

namespace FastEndpointsApi.Features.AddWarehouse;

public class AddWarehouseRequestValidator : Validator<AddWarehouseRequest>
{
    public AddWarehouseRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty();

        RuleFor(r => r.Location)
            .NotEmpty();
    }
}