using AutoMapper;
using Vemo.Application.Common.Utils;
using Vemo.Application.Features.Users.Commands.User.CreateUser;
using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password)));

        CreateMap<User, UserResponseDto>();
    }
}