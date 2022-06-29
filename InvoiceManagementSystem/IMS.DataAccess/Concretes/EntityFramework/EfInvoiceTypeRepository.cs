using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.DataAccess.Context.EntityFramework;
using IMS.Entities.Concrete;
namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfInvoiceTypeRepository : EfEntityRepositoryBase<InvoiceType, InvoiceManagementDbContext>, IInvoiceTypeRespository
    {
        public EfInvoiceTypeRepository(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
