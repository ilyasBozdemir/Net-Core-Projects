using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfInvoicePaymentRepository : EfEntityRepositoryBase<InvoicePayment, IMSDbContext>, IInvoicePaymentRepository
    {
        public EfInvoicePaymentRepository(IMSDbContext context) : base(context)
        {

        }
    }
}
