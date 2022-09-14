using AutoFixture;
using Dev.Freela.Application.Queries.GetUsers;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Queries
{
    public class GetUserByIdQueryHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public GetUserByIdQueryHandlerTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task OneUserExists_Executed_ReturnUserViewModel()
        {
            // Arrange
            var fixture = new Fixture();

            var getUserByIdQuery = fixture.Create<GetUserByIdQuery>();
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(_userRepositoryMock.Object);

            var user = fixture.Create<User>();

            _userRepositoryMock.Setup(x => x.GetByIdAsync(getUserByIdQuery.Id))
                .Returns(Task.FromResult(user));

            // Action
            var result = await getUserByIdQueryHandler.Handle(getUserByIdQuery, new CancellationToken());

            // Assert
            _userRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task NotExistUser_Executed_ReturnUserViewModelEmpty()
        {
            // Arrange
            var fixture = new Fixture();

            var getUserByIdQuery = fixture.Create<GetUserByIdQuery>();
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(_userRepositoryMock.Object);

            // Action
            await getUserByIdQueryHandler.Handle(getUserByIdQuery, new CancellationToken());

            // Assert
            _userRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
