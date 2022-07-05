namespace Application.ViewModels.Payment
{
    public class CreatePayOrderViewModel
    {
        public Guid InvoiceId { get; set; }
        public Guid UserId { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }
        public decimal Amount { get; set; }
    }
}
