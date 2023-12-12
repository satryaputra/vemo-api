﻿using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Dtos;
using Vemo.Application.Features.Users.Commands.User.CreateUser;
using Vemo.Application.Features.Users.Queries.User.GetUserById;
using Vemo.Domain.Entities.Users;

namespace Vemo.Application.UnitTests.Features.Users.Command;

public class CreateUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnToken_WhenCreatingUser()
    {
        // Arrange
        var command = new CreateUserCommand
        {
            Name = "SomeName",
            Email = "someemail@email.com",
            Password = "SomePassword1",
            Role = "SomeRole"
        };

        // Mock dependencies
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<User>(It.IsAny<CreateUserCommand>()))
            .Returns(new User());

        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        userRoleRepositoryMock.Setup(x => x.GetUserRoleByRoleAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new UserRole());

        var userAuthInfoRepositoryMock = new Mock<IUserAuthInfoRepository>();
        userAuthInfoRepositoryMock
            .Setup(x => x.GetUserAuthInfoByUserIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new UserAuthInfo());

        var handler = new CreateUserCommandHandler(
            mapperMock.Object,
            userRepositoryMock.Object,
            userRoleRepositoryMock.Object,
            userAuthInfoRepositoryMock.Object
        );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.AccessToken.Should().NotBeNull();
        result.RefreshToken.Should().NotBeNull();
        result.RefreshTokenExpires.Should().BeBefore(DateTime.UtcNow.AddDays(7));
    }

    [Fact]
    public async Task Handle_ShouldReturnUserResponseDto_WhenGetUserById()
    {
        // Arrange
        var userIdToGet = Guid.NewGuid();

        var expectedUserResponseDto = new UserResponseDto
        {
            UserId = userIdToGet,
            Name = "SomeName",
            Email = "someemail@email.com",
            Role = "SomeRole"
        };

        var query = new GetUserByIdQuery { UserId = userIdToGet };

        // Mock dependencies
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<UserResponseDto>(It.IsAny<User>()))
            .Returns(expectedUserResponseDto);

        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.GetUserByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        userRoleRepositoryMock.Setup(x => x.GetUserRoleByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new UserRole());

        var handler = new GetUserByIdQueryHandler(
            mapperMock.Object,
            userRepositoryMock.Object,
            userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.UserId.Should().Be(expectedUserResponseDto.UserId);
        result.Name.Should().Be(expectedUserResponseDto.Name);
        result.Email.Should().Be(expectedUserResponseDto.Email);
        result.Role.Should().Be(expectedUserResponseDto.Role);
    }
}