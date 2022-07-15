using Application.Interfaces.UnitOfWork;
using Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMSDbContext _context;

       // private EfApartmentRepository _apartments;
        //private EfApartmentTypeRepository _apartmentTypes;
        //private EfHouseRepository _houses;
        //private EfInvoicePaymentRepository _invoicePayments;
        //private EfInvoiceRepository _invoices;
        //private EfInvoiceTypeRepository _invoiceTypes;
        //private EfLogRepository _logs;
        //private EfResidentRepository _residents;
        //private EfUserRepository _users;
        //IApartmentRepository IUnitOfWork.Apartments
           //        => _apartments ?? new(_context);
        //IHouseRepository IUnitOfWork.Houses 
        //    => _houses ?? new (_context);
       
        //IApartmentTypeRepository IUnitOfWork.ApartmentTypes
        //    => _apartmentTypes ?? new(_context);
        //IInvoicePaymentRepository IUnitOfWork.InvoicePayments
        //    => _invoicePayments ?? new(_context);
        //IInvoiceRepository IUnitOfWork.Invoices 
        //    => _invoices ?? new(_context);
        //IInvoiceTypeRepository IUnitOfWork.InvoiceTypes
        //         => _invoiceTypes ?? new(_context);
        //ILogRepository IUnitOfWork.Logs
        //         => _logs ?? new(_context);
        //IResidentRepository IUnitOfWork.Residents
        //        => _residents ?? new(_context);
        //IUserRepository IUnitOfWork.Users
        //         => _users ?? new(_context);

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_context.Database.BeginTransactionAsync() == null)
                return null;
            return _context.Database.BeginTransactionAsync();
        }
       
        ValueTask IAsyncDisposable.DisposeAsync()
        {
            try
            {
                _context.Dispose();
                return default;
            }
            catch (Exception exception)
            {
                return new ValueTask(Task.FromException(exception));
            }
        }

    }
}
