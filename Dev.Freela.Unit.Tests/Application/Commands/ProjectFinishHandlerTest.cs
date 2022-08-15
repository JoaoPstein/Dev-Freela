using AutoFixture;
using Dev.Freela.Application.Commands.ProjectFinish;
using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Dev.Freela.Infrastructure.Payments;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Freela.Unit.Tests.Application.Commands
{
    public class ProjectFinishHandlerTest
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly Mock<IPaymentService> _paymentServiceMock;

        public ProjectFinishHandlerTest()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();
        }

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnFinishProject()
        {
            // Arrange
            var fixture = new Fixture();

            var createProjectCommand = fixture.Create<ProjectFinishCommand>();
            var paymentInfoDto = fixture.Create<PaymentInfoDto>();

            var project = fixture.Create<Project>();

            _projectRepositoryMock.Setup(x => x.GetByIdAsync(createProjectCommand.Id))
                .Returns(Task.FromResult(project));

            _paymentServiceMock.Setup(x => x.ProcessPayment(paymentInfoDto));

            var createCommentProject = new ProjectFinishCommandHandler(
                _projectRepositoryMock.Object, _paymentServiceMock.Object);

            project.SetPaymentPending();

            // Action
            var result = await createCommentProject.Handle(createProjectCommand, new CancellationToken());

            // Assert
            _projectRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _paymentServiceMock.Verify(x => x.ProcessPayment(It.IsAny<PaymentInfoDto>()), Times.Once);

            Assert.True(result);
        }
    }
}
