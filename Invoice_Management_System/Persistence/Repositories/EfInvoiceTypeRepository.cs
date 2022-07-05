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
    public class EfInvoiceTypeRepository : EfEntityRepositoryBase<InvoiceType, IMSDbContext>, IInvoiceTypeRepository
    {
        public EfInvoiceTypeRepository(IMSDbContext context) : base(context)
        {

        }
    }
}
