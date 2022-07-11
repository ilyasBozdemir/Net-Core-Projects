using Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        public IApartmentRepository Apartments { get; }

        //public IApartmentTypeRepository ApartmentTypes { get; }
        //public IHouseRepository Houses { get; }
        //public IInvoicePaymentRepository InvoicePayments { get; }
        //public IInvoiceRepository Invoices { get; }
        //public IInvoiceTypeRepository InvoiceTypes { get; }
        //public ILogRepository Logs { get; }
        //public IResidentRepository Residents { get; }
        //public IUserRepository Users { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public int SaveChanges();
    }
}
