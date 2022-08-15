using AutoFixture;
using Dev.Freela.Application.Commands.CreateProject;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class CreateProjectCommandHandlerTest
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;

        public CreateProjectCommandHandlerTest()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
        }

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var fixture = new Fixture();

            var createProjectCommand = fixture.Create<CreateProjectCommand>();

            var createProjectCommandHandler = new CreateProjectCommandHandler(_projectRepositoryMock.Object);

            // Action
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            _projectRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
