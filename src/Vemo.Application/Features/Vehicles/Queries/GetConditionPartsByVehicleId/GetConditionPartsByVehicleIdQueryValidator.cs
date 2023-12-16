namespace Vemo.Application.Features.Vehicles.Queries.GetConditionPartsByVehicleId;

/// <summary>
/// GetConditionPartsByVehicleIdQueryValidator
/// </summary>
public class GetConditionPartsByVehicleIdQueryValidator : AbstractValidator<GetConditionPartsByVehicleIdQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GetConditionPartsByVehicleIdQueryValidator"/> class.
    /// </summary>
    public GetConditionPartsByVehicleIdQueryValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}