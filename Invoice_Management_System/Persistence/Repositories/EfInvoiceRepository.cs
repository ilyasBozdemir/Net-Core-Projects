using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfInvoiceRepository : EfEntityRepositoryBase<Invoice, IMSDbContext>, IInvoiceRepository
    {
        public EfInvoiceRepository(IMSDbContext context) : base(context)
        {

        }
    }
}
