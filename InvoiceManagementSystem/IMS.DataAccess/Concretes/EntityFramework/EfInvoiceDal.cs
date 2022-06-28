using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, InvoiceManagementDbContext>, IInvoiceRepository
    {
        public EfInvoiceDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<InvoiceDto> GetAllUserInvoiceDetail(int UserId)
        {
            var result = from i in _context.Invoices
                         join it in _context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                         join h in _context.Houses on i.HouseId equals h.Id
                         join a in _context.Apartments on h.ApartmentId equals a.Id
                         join res in _context.Residents on h.Id equals res.HouseId
                         where res.UserId == UserId
                         select new InvoiceDto()
                         {
                             Id = i.Id,
                             House = $"{a.Name} no: {h.DoorNumber}",
                             InvoiceType = it.Name,
                             Amount = i.Amount,
                             InvoiceDate = i.InvoiceDate,
                             Status = i.Status
                         };
            return result;
        }

        public IEnumerable<InvoiceDto> GetAllInvoiceDetail()
        {
            var result = from i in _context.Invoices
                         join it in _context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                         join h in _context.Houses on i.HouseId equals h.Id
                         join a in _context.Apartments on h.ApartmentId equals a.Id
                         select new InvoiceDto()
                         {
                             Id = i.Id,
                             House = $"{a.Name} no: {h.DoorNumber}",
                             InvoiceType = it.Name,
                             Amount = i.Amount,
                             InvoiceDate = i.InvoiceDate,
                             Status = i.Status
                         };
            return result;
        }

        public InvoiceDto GetInvoiceDetail(int id)
        {
            var result = from i in _context.Invoices
                         join it in _context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                         join h in _context.Houses on i.HouseId equals h.Id
                         join a in _context.Apartments on h.ApartmentId equals a.Id
                         where i.Id == id
                         select new InvoiceDto()
                         {
                             Id = i.Id,
                             House = $"{a.Name} no: {h.DoorNumber}",
                             InvoiceType = it.Name,
                             Amount = i.Amount,
                             InvoiceDate = i.InvoiceDate,
                             Status = i.Status
                         };
            return result.SingleOrDefault();
        }
    }
}
