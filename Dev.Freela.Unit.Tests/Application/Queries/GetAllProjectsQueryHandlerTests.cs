using AutoFixture;
using Dev.Freela.Application.Queries.Projects;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;

        public GetAllProjectsQueryHandlerTests()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();    
        }

        [Fact]
        public async Task ThreeProjectsExists_Executed_ReturnTrheeProjectsViewModel()
        {
            // Arrange
            var fixture = new Fixture();

            var projectA = fixture.Create<Project>();
            var projectB = fixture.Create<Project>();
            var projectC = fixture.Create<Project>();

            var projects = new List<Project>();
            projects.Add(projectA);
            projects.Add(projectB);
            projects.Add(projectC);

            _projectRepositoryMock.Setup(x => x.GetAll()).Returns(Task.FromResult(projects));

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectQueryHandler(_projectRepositoryMock.Object);

            // Action
            var projectViewModelResult = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projects);
            Assert.NotEmpty(projects);
            Assert.Equal(projects.Count, projectViewModelResult.Count);

            _projectRepositoryMock.Verify(x => x.GetAll().Result, Times.Once);
        }
    }
}
