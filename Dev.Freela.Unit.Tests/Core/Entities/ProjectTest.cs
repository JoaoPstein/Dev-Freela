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

        [Fact]
        public void TestIfCancelProjectWork()
        {
            // Arrange
            var project = CreateProject();

            // Action
            project.Start();
            project.Cancell();

            // Assert
            Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
        }

        [Fact]
        public void TestIfSetPaymentPendingProjectWork()
        {
            // Arrange
            var project = CreateProject();

            // Action
            project.SetPaymentPending();

            // Assert
            Assert.Equal(ProjectStatusEnum.PaymentPending, project.Status);
        }

        [Fact]
        public void TestIfFinishProjectWork()
        {
            // Arrange
            var project = CreateProject();

            // Action
            project.Start();
            project.Finish();

            // Assert
            Assert.Equal(ProjectStatusEnum.Finished, project.Status);
        }

        [Fact]
        public void TestIfUpdateProjectWork()
        {
            // Arrange
            var project = CreateProject();

            // Action
            project.Update("Novo titulo", "Nova descrição", 1234);

            // Assert
            Assert.Equal("Novo titulo", project.Title);
            Assert.Equal("Nova descrição", project.Description);
            Assert.Equal(1234, project.TotalCost);
        }

        private static Project CreateProject()
        {
            var fixture = new Fixture();

            var project = fixture.Create<Project>();
            return project;
        }
    }
}
