using AutoFixture;
using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Services;
using Dev.Freela.Infrastructure.Payments;
using Moq;

namespace Dev.Freela.Unit.Tests.Infrastructure
{
    public class PaymentsServiceTest
    {
        private readonly IPaymentService _paymentService;
        private readonly Mock<IMessageBusService> _messageBusServiceMock;

        public PaymentsServiceTest()
        {
            _messageBusServiceMock = new Mock<IMessageBusService>();

            _paymentService = new PaymentService(_messageBusServiceMock.Object);
        }

        [Fact]
        public void InputDataIsOk_Executed_ProcessPayment()
        {
            // Arrange
            var fixture = new Fixture();

            var paymentInfoDto = fixture.Create<PaymentInfoDto>();

            // Action
            _paymentService.ProcessPayment(paymentInfoDto);

            // Assert
            _messageBusServiceMock.Verify(x => x.Publish(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once);
        }
    }
}
