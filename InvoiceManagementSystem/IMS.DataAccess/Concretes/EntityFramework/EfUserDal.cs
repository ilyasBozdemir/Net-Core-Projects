using IMS.Core.DataAccess.EntityFramework;
using IMS.Core.Entities.Concretes;
using IMS.DataAccess.Abstracts;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, InvoiceManagementDbContext>, IUserRepository
    {
        public EfUserDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
