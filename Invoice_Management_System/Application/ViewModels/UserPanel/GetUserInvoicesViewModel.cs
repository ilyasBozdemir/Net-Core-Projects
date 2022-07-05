using System;

namespace Application.ViewModels.UserPanel
{
    public class GetUserInvoicesViewModel
    {
        public Guid Id { get; set; }
        public string InvoiceType { get; set; }
        public string House { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
