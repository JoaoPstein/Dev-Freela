using AutoFixture;
using Dev.Freela.Application.Commands.ProjectStart;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class ProjectStartCommandHandlerTest
    {
        private readonly Mock<IProjectRepository> _projectRepository;

        public ProjectStartCommandHandlerTest()
        {
            _projectRepository = new Mock<IProjectRepository>();
        }

        [Fact]
        public async Task InputDataIsOk_Execute_StartInProject()
        {
            // Arrange
            var fixture = new Fixture();

            var projectStartCommand = fixture.Create<ProjectStartCommand>();

            var projectStartCommandHandler = new ProjectStartCommandHandler(_projectRepository.Object);

            var project = fixture.Create<Project>();

            _projectRepository.Setup(x => x.GetByIdAsync(projectStartCommand.Id))
                .Returns(Task.FromResult(project));

            // Action
            await projectStartCommandHandler.Handle(projectStartCommand, new CancellationToken());

            // Assert
            _projectRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _projectRepository.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
