namespace Vemo.Application.Features.Vehicles.Commands.AddVehicle;

/// <summary>
/// AddVehicleCommandValidator
/// </summary>
public class AddVehicleCommandValidator : AbstractValidator<AddVehicleCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="AddVehicleCommandValidator"/> class.
    /// </summary>
    public AddVehicleCommandValidator()
    {
        RuleFor(x => x.VehicleName)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(5).WithMessage("{PropertyName} harus 5 karakter atau lebih");
        
        RuleFor(x => x.OwnerName)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(3).WithMessage("{PropertyName} harus 3 karakter atau lebih");
        
        RuleFor(x => x.VehicleType)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .Must(role => role is "matic" or "manual").WithMessage("{PropertyName} harus 'matic' atau 'manual'");
        
        RuleFor(x => x.LicensePlate)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(3).WithMessage("{PropertyName} harus 3 karakter atau lebih")
            .Must(BeAlphanumeric).WithMessage("{PropertyName} tidak valid");

        RuleFor(x => x.PurchasingDate)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");

        RuleFor(x => x.LastMaintenance)
            .NotNull().WithMessage("{PropertyName} wajib diisi");

        RuleFor(x => x.UserId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
    
    /// <summary>
    /// BeAlphanumeric
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <returns></returns>
    private static bool BeAlphanumeric(string licensePlate)
    {
        return !string.IsNullOrWhiteSpace(licensePlate) && licensePlate.All(char.IsLetterOrDigit);
    }
}