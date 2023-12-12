using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Users.Commands.UpdateUser;

/// <summary>
/// UpdateUserCommandHandler
/// </summary>
internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="UpdateUserCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="ConflictException"></exception>
    public async Task<GenericResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
        
        if (user.Name is null && user.Email is null)
        {
            throw new BadRequestException("Setidaknya harus ada satu property yang diupdate");
        }

        if (user.Name == request.Name || user.Email == request.Email)
        {
            throw new ConflictException("Nama atau Email tidak boleh sama dengan sebelumnya");
        }
        
        var nameToBeUpdate = request.Name ?? user.Name;
        var emailToBeUpdate = request.Email ?? user.Email;

        await _userRepository.UpdateUserAsync(user.Id, nameToBeUpdate!, emailToBeUpdate, cancellationToken);

        return new GenericResponseDto("Update user berhasil");
    }
}