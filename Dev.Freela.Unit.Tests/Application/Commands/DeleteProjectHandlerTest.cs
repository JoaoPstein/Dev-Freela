using AutoFixture;
using Dev.Freela.Application.Commands.DeleteProject;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class DeleteProjectHandlerTest
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;

        public DeleteProjectHandlerTest()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
        }

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnDeletedProjectId()
        {
            // Arrange
            var fixture = new Fixture();

            var deleteProjectCommand = fixture.Create<DeleteProjectCommand>();

            var deleteCommentProject = new DeleteProjectHandler(_projectRepositoryMock.Object);

            // Action
            await deleteCommentProject.Handle(deleteProjectCommand, new CancellationToken());

            // Assert
            _projectRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
