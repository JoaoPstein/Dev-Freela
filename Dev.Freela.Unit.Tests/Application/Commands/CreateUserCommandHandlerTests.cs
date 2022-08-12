using AutoFixture;
using Dev.Freela.Application.Commands.CreateUsers;
using Dev.Freela.Core.Repositories;
using Dev.Freela.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IAuthService> _authServiceMock;

        public CreateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _authServiceMock = new Mock<IAuthService>();
        }

        [Fact]
        public async Task InputDataIsOk_Execute_CreateNewUser()
        {
            // Arrange
            var fixture = new Fixture();

            fixture.Customize<CreateUserCommand>(x => x
            .With(y => y.Password, "Teste"));

            var createUserCommand = fixture.Create<CreateUserCommand>();

            _authServiceMock.Setup(x =>
                x.ComputeSha256Hash(createUserCommand.Password)).Returns(createUserCommand.Password);

            var createUserCommandHandler = new CreateUserCommandHandler(_userRepositoryMock.Object,
                _authServiceMock.Object);

            // Action
            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            
        }
    }
}
