using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfInvoicePaymentDal : EfEntityRepositoryBase<InvoicePayment, InvoiceManagementDbContext>, IInvoicePaymentRepository
    {
        public EfInvoicePaymentDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
