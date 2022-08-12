using AutoFixture;
using Dev.Freela.Application.Commands.CreateComment;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class CreateCommentHandlerTests
    {
        private readonly Mock<IProjectCommentRepository> _projectCommentMock;

        public CreateCommentHandlerTests()
        {
            _projectCommentMock = new Mock<IProjectCommentRepository>();    
        }

        [Fact]
        public async Task InputDataIsOk_Execute_CreateCommentInProject()
        {
            // Arrange
            var fixture = new Fixture();

            var createProjectCommand = fixture.Create<CreateCommentCommand>();

            var createCommentProject = new CreateCommentHandler(_projectCommentMock.Object);

            // Action
            await createCommentProject.Handle(createProjectCommand, new CancellationToken());

            // Assert
            _projectCommentMock.Verify(x => x.CreateCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}
