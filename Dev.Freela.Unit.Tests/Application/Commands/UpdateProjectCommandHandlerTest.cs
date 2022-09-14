using AutoFixture;
using Dev.Freela.Application.Commands.UpdateProject;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class UpdateProjectCommandHandlerTest
    {
        private readonly Mock<IProjectRepository> _projectRepository;

        public UpdateProjectCommandHandlerTest()
        {
            _projectRepository = new Mock<IProjectRepository>();
        }

        [Fact]
        public async Task InputDataIsOk_Execute_UpdateProject()
        {
            // Arrange
            var fixture = new Fixture();

            var updateProjectCommand = fixture.Create<UpdateProjectCommand>();

            var updateProjectCommandHandler = new UpdateProjectCommandHandler(_projectRepository.Object);

            var project = fixture.Create<Project>();

            _projectRepository.Setup(x => x.GetByIdAsync(updateProjectCommand.Id))
                .Returns(Task.FromResult(project));

            project.Update("Novo titulo", "Nova descrição", 12332);

            // Action
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            // Assert
            _projectRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _projectRepository.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
