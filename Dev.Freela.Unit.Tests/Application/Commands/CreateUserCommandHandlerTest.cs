using AutoFixture;
using Dev.Freela.Application.Commands.CreateUsers;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Dev.Freela.Core.Services;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class CreateUserCommandHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IAuthService> _authServiceMock;

        public CreateUserCommandHandlerTest()
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

            _authServiceMock.Setup(x => x.ComputeSha256Hash(createUserCommand.Password)).Returns("asdasdasd123441awsd1231afd");

            var createUserCommandHandler = new CreateUserCommandHandler(_userRepositoryMock.Object,
                _authServiceMock.Object);

            // Action
            await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            _authServiceMock.Verify(x => x.ComputeSha256Hash(It.IsAny<string>()), Times.Once);
            _userRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
