using AutoFixture;
using Dev.Freela.Application.Queries.GetProjectById;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Queries
{
    public class GetProjectIdQueryHandlerTest
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public GetProjectIdQueryHandlerTest()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task OneProjectsExists_Executed_ReturnOneProjectDetailsViewModel()
        {
            // Arrange
            var fixture = new Fixture();

            var getProjectByIdQuery = fixture.Create<GetProjectByIdQuery>();
            var getProjectByIdQueryHandler = new GetProjectIdQueryHandler(_projectRepositoryMock.Object);

            var client = fixture.Create<User>();
            var freelancer = fixture.Create<User>();

            _userRepositoryMock.Setup(x => x.GetByIdAsync(client.Id)).Returns(Task.FromResult(client));
            _userRepositoryMock.Setup(x => x.GetByIdAsync(freelancer.Id)).Returns(Task.FromResult(freelancer));

            fixture.Customize<Project>(x => x
            .With(y => y.Client, client)
            .With(y => y.Freelancer, freelancer));

            var project = fixture.Create<Project>();

            _projectRepositoryMock.Setup(x => x.GetByIdAsync(getProjectByIdQuery.Id))
               .Returns(Task.FromResult(project));

            new ProjectDetailsViewModel(project.Id, project.Title, project.Description,
                project.TotalCost, project.StartedAt, project.FinishedAt,
                client.Name, freelancer.Name);

            // Action
            var result = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            _projectRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task NotExistsOneProject_NotExecuted_ReturnProjectDetailsViewModel()
        {
            // Arrange
            var fixture = new Fixture();

            var getProjectByIdQuery = fixture.Create<GetProjectByIdQuery>();
            var getProjectByIdQueryHandler = new GetProjectIdQueryHandler(_projectRepositoryMock.Object);

            // Action
            await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            _projectRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
