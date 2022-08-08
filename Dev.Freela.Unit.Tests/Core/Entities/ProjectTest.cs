using AutoFixture;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Enums;

namespace Dev.Freela.Unit.Tests.Core.Entities
{
    public class ProjectTest
    {

        [Fact]
        public void TestIfProjectStartWork()
        {
            // Arrange
            var project = CreateProject();

            // Action
            project.Start();

            // Assert
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
            Assert.NotEmpty(project.Title);
            Assert.NotEmpty(project.Description);
        }

        private static Project CreateProject()
        {
            var fixture = new Fixture();

            var project = fixture.Create<Project>();
            return project;
        }
    }
}
