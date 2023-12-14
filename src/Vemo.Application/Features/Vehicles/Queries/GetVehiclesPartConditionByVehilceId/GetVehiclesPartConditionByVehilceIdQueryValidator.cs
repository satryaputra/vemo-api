namespace Vemo.Application.Features.Vehicles.Queries.GetVehiclesPartConditionByVehilceId;

/// <summary>
/// GetVehiclesPartConditionByVehilceIdQueryValidator
/// </summary>
public class GetVehiclesPartConditionByVehilceIdQueryValidator : AbstractValidator<GetVehiclesPartConditionByVehilceIdQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GetVehiclesPartConditionByVehilceIdQueryValidator"/> class.
    /// </summary>
    public GetVehiclesPartConditionByVehilceIdQueryValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}