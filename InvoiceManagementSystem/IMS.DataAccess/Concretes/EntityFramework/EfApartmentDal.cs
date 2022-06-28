using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfApartmentDal : EfEntityRepositoryBase<Apartment, InvoiceManagementDbContext>, IApartmentRepository
    {
        public EfApartmentDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
