using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Services;
using System.Text;
using System.Text.Json;

namespace Dev.Freela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QueueName = "Payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDto paymentInfoDTO)
        {
            var paymentsInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoByte = Encoding.UTF8.GetBytes(paymentsInfoJson);

            _messageBusService.Publish(QueueName, paymentInfoByte);
        }
    }
}
