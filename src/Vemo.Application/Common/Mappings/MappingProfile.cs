using AutoMapper;
using Vemo.Application.Common.Utils;
using Vemo.Application.Features.Users.Commands.CreateUser;
using Vemo.Application.Features.Vehicles.Commands.AddPart;
using Vemo.Application.Features.Vehicles.Commands.AddVehicle;
using Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;
using Vemo.Domain.Entities.Users;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Mappings;

/// <summary>
/// MappingProfile
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initialize a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password)));

        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddVehicleCommand, Vehicle>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.VehicleName))
            .ForMember(dest => dest.PurchasingDate,
                opt => opt.MapFrom(src => DateTimeUtcConverter.FromIsoString(src.PurchasingDate)))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.VehicleType));

        CreateMap<Vehicle, VehicleResponseDto>()
            .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.VehicleName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => src.Type));

        CreateMap<AddPartVehicleCommand, Part>();

        CreateMap<RequestMaintenanceCommand, MaintenanceVehicle>();
    }
}
