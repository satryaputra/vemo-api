using MediatR;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Features.Users.Commands.UserRole.CreateUserRole;
using Vemo.Application.Features.Users.Commands.UserRole.DeleteUserRole;
using Vemo.Application.Features.Users.Queries.UserRole.GetUserRoleById;
using Vemo.Application.Features.Users.Queries.UserRole.GetUserRoles;
using Vemo.Domain.Entities.Users;

namespace Vemo.Application.UnitTests.Features.Users.Command;

public class UserRoleCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnSuccessResult_WhenCreatingUserRole()
    {
        // Arrange
        var newUserRoleId = Guid.NewGuid();
        var newUserRole = "SomeRole";
        
        var expectedUserRole = new UserRole { Id = newUserRoleId, Role = newUserRole };
        
        var command = new CreateUserRoleCommand { Role = newUserRole };
        
        // Mock dependencies
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        userRoleRepositoryMock.Setup(x => x.CreateUserRoleAsync(newUserRole, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUserRole);

        var handler = new CreateUserRoleCommandHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(newUserRoleId);
        result.Role.Should().BeEquivalentTo(newUserRole);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnUserRoles_WhenGettingUserRoles()
    {
        // Arrange
        var expectedUserRoles = new List<UserRole>
        {
            new() { Id = Guid.NewGuid(), Role = "Role1" },
            new() { Id = Guid.NewGuid(), Role = "Role2" },
        };

        // Mock dependencies
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        userRoleRepositoryMock.Setup(x => x.GetUserRolesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUserRoles);

        var handler = new GetUserRolesQueryHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(new GetUserRolesQuery(), CancellationToken.None);

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
        var expectedUserRole = new UserRole { Id = userRoleIdToGet, Role = "SomeRole" };
        var query = new GetUserRoleByIdQuery { UserRoleId = userRoleIdToGet };
        
        // Mock dependencies
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        userRoleRepositoryMock.Setup(x => x.GetUserRoleByIdAsync(userRoleIdToGet, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUserRole);

        var handler = new GetUserRoleByIdQueryHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedUserRole.Id);
        result.Role.Should().Be(expectedUserRole.Role);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnSuccessResult_WhenDeletingUserRole()
    {
        // Arrange
        var userRoleIdToDelete = Guid.NewGuid();
        
        var command = new DeleteUserRoleCommand { UserRoleId = userRoleIdToDelete };
        
        // Mock dependencies
        var userRoleRepositoryMock = new Mock<IUserRoleRepository>();
        userRoleRepositoryMock.Setup(x => x.DeleteUserRoleAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new DeleteUserRoleCommandHandler(userRoleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);
    }
}