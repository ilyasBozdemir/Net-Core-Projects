using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.DataAccess.Context.EntityFramework;
using IMS.Entities.Concrete;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfInvoicePaymentRepository : EfEntityRepositoryBase<InvoicePayment, InvoiceManagementDbContext>, IInvoicePaymentRepository
    {
        public EfInvoicePaymentRepository(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
