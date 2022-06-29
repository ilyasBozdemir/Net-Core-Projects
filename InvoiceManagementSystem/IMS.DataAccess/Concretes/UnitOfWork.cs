using IMS.DataAccess.Abstracts;
using IMS.DataAccess.Concretes.EntityFramework;
using IMS.DataAccess.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InvoiceManagementDbContext _context;

        private EfApartmentRepository _apartments;
        private EfFlatTypeRepository  _flatTypes;
        private EfHouseRepository _houses;
        private EfInvoicePaymentRepository _invoicePayments;
        private EfInvoiceRepository _invoices;
        private EfInvoiceTypeRepository _invoiceTypes;
        private EfLogRepository _logs;
        private EfResidentRepository _residents;
        private EfUserRepository _users;

        public UnitOfWork(InvoiceManagementDbContext context)
        {
            _context = context;
        }
        public IApartmentRepository Apartments
            => _apartments ?? new EfApartmentRepository(_context);
        public IFlatTypeRepository FlatTypes
            => _flatTypes ?? new EfFlatTypeRepository(_context);
        public IHouseRepository Houses
            => _houses ?? new EfHouseRepository(_context);
        public IInvoicePaymentRepository InvoicePayments
            => _invoicePayments ?? new EfInvoicePaymentRepository(_context);
        public IInvoiceRepository Invoices
            => _invoices ?? new EfInvoiceRepository(_context);
        public IInvoiceTypeRespository InvoiceTypes
            => _invoiceTypes ?? new EfInvoiceTypeRepository(_context);
        public ILogRepository Logs =>
            _logs ?? new EfLogRepository(_context);

        public IResidentRepository Residents
            => _residents ?? new EfResidentRepository(_context);

        public IUserRepository Users =>
            _users ?? new EfUserRepository(_context);

        public void Dispose()
          => _context.Dispose();

        public int SaveChanges()
            => _context.SaveChanges();
       
    }
}
