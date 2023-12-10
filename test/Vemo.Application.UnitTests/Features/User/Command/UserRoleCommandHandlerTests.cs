using MediatR;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Features.User.Commands.CreateUserRole;
using Vemo.Application.Features.User.Commands.DeleteUserRole;
using Vemo.Application.Features.User.Queries.GetUserRoleById;
using Vemo.Application.Features.User.Queries.GetUserRoles;
using Vemo.Domain.Entities.User;

namespace Vemo.Application.UnitTests.Features.User.Command;

public class UserRoleCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnSuccessResult_WhenCreatingUserRole()
    {
        // Arrange
        var newUserRoleId = Guid.NewGuid();
        var newUserRole = "SomeRole";
        
        var command = new CreateUserRoleCommand { Role = newUserRole };
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        
        var expectedUserRole = new UserRole { Id = newUserRoleId, Role = newUserRole };
        userRoleRepositoryMock.Setup(x => x.CreateUserRoleAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUserRole);

        var handler = new CreateUserRoleCommandHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(newUserRoleId);
        result.Role.Should().BeEquivalentTo(newUserRole);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnUserRoles_WhenGettingUserRoles()
    {
        // Arrange
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();

        var expectedUserRoles = new List<UserRole>
        {
            new UserRole { Id = Guid.NewGuid(), Role = "Role1" },
            new UserRole { Id = Guid.NewGuid(), Role = "Role2" },
        };

        userRoleRepositoryMock.Setup(x => x.GetUserRolesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUserRoles);

        var handler = new GetUserRolesQueryHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(new GetUserRolesQuery(), default);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(expectedUserRoles.Count); 
        result.Should().Contain(r => r.Role == "Role1");
        result.Should().Contain(r => r.Role == "Role2");
    }
    
    [Fact]
    public async Task Handle_ShouldReturnUserRole_WhenGettingUserRoleById()
    {
        // Arrange
        var userRoleIdToGet = Guid.NewGuid();
        var query = new GetUserRoleByIdQuery { UserRoleId = userRoleIdToGet };
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();

        var expectedUserRole = new UserRole { Id = userRoleIdToGet, Role = "SomeRole" };
        userRoleRepositoryMock.Setup(x => x.GetUserRoleByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUserRole);

        var handler = new GetUserRoleByIdQueryHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(userRoleIdToGet);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnSuccessResult_WhenDeletingUserRole()
    {
        // Arrange
        var userRoleIdToDelete = Guid.NewGuid();
        var command = new DeleteUserRoleCommand { UserRoleId = userRoleIdToDelete };
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        
        userRoleRepositoryMock.Setup(x => x.DeleteUserRoleAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new DeleteUserRoleCommandHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().Be(Unit.Value);
    }
}