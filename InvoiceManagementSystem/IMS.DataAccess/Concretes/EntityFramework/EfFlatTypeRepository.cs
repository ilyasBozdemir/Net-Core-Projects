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
    public class EfFlatTypeRepository : EfEntityRepositoryBase<FlatType, InvoiceManagementDbContext>, IFlatTypeRepository
    {
        public EfFlatTypeRepository(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
