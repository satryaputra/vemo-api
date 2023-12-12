namespace Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;

/// <summary>
/// ApproveVehicleValidator
/// </summary>
public class ApproveVehicleValidator : AbstractValidator<ApproveVehicleCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ApproveVehicleValidator"/> class.
    /// </summary>
    public ApproveVehicleValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}