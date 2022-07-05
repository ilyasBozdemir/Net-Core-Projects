using System;

namespace Application.ViewModels.Invoice
{
    public class CreateInvoiceViewModel
    {
        public Guid InvoiceTypeId { get; set; }
        public Guid HouseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
