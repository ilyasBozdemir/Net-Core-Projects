using System;

namespace Application.ViewModels.Invoice
{
    public class UpdateInvoiceViewModel
    {
        public Guid Id { get; set; }
        public Guid InvoiceTypeId { get; set; }
        public Guid HouseId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
