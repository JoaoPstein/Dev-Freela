using Dev.Freela.Core.DTOs;

namespace Dev.Freela.Infrastructure.Payments
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
