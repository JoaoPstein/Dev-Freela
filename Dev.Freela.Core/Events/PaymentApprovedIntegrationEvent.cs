using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Core.Events
{
    [ExcludeFromCodeCoverage]
    public class PaymentApprovedIntegrationEvent
    {
        public int ProjectId { get; set; }
    }
}
