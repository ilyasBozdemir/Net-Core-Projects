using System;

namespace IMS.DataAccess.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IApartmentRepository Apartments { get; }
        IApartmentTypeRepository FlatTypes { get; }
        IHouseRepository Houses { get; }
        IInvoicePaymentRepository InvoicePayments { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceTypeRespository InvoiceTypes { get; }
        ILogRepository Logs { get; }
        IResidentRepository Residents { get; }
        IUserRepository Users { get; }
        
        int SaveChanges();
    }
}
