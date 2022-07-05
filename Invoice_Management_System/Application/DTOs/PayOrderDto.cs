using Domain.Common;

namespace Application.DTOs
{
    public class PayOrderDto : BaseDTO
    {
        public Guid InvoiceId { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }
        public decimal Amount { get; set; }
    }
}
