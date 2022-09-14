using AutoFixture;
using Dev.Freela.Application.Commands.LoginUser;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Dev.Freela.Core.Services;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class LoginUserCommandHandlerTest
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public LoginUserCommandHandlerTest()
        {
            _authServiceMock = new Mock<IAuthService>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task InputDataIsOk_Execute_LoginIntoSystemWithUser()
        {
            // Arrange
            var fixture = new Fixture();

            var createLoginUserCommand = fixture.Create<LoginUserCommand>();

            var user = fixture.Create<User>();

            var senhaHash = "asdasdasd123441awsd1231afd";

            _authServiceMock.Setup(x => x.ComputeSha256Hash(createLoginUserCommand.Password)).Returns(senhaHash);

            _userRepositoryMock.Setup(x => x.GetUserByEmailAndPasswordAsync(createLoginUserCommand.Email,
                senhaHash)).Returns(Task.FromResult(user));

            _authServiceMock.Setup(x => x.GenerateJwtToken(user.Email, user.Role)).Returns("token");

            var createLoginUserCommandHandler = new LoginUserCommandHandler(_authServiceMock.Object, _userRepositoryMock.Object);

            // Action
            var result = await createLoginUserCommandHandler.Handle(createLoginUserCommand, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            _authServiceMock.Verify(x => x.ComputeSha256Hash(It.IsAny<string>()), Times.Once);
            _authServiceMock.Verify(x => x.GenerateJwtToken(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _userRepositoryMock.Verify(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task InputDataIsNotOk_NotExecute_LoginIntoSystem()
        {
            // Arrange
            var fixture = new Fixture();

            var createLoginUserCommand = fixture.Create<LoginUserCommand>();
            var createLoginUserCommandHandler = new LoginUserCommandHandler(_authServiceMock.Object, _userRepositoryMock.Object);

            // Action
            var result = await createLoginUserCommandHandler.Handle(createLoginUserCommand, new CancellationToken());

            // Assert
            Assert.Empty(result.Email);
            Assert.Empty(result.Token);
        }
    }
}
