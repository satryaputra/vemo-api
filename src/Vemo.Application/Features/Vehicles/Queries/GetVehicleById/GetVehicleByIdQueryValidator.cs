namespace Vemo.Application.Features.Vehicles.Queries.GetVehicleById;

/// <summary>
/// GetVehicleByIdQueryValidator
/// </summary>
public class GetVehicleByIdQueryValidator : AbstractValidator<GetVehicleByIdQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GetVehicleByIdQueryValidator"/> class.
    /// </summary>
    public GetVehicleByIdQueryValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}