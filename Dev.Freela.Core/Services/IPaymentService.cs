using Dev.Freela.Core.DTOs;

namespace Dev.Freela.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDto paymentInfoDTO);
    }
}
