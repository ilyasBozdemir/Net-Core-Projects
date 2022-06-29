using IMS.Core.DataAccess.EntityFramework;
using IMS.Core.Entities.Concretes;
using IMS.DataAccess.Abstracts;
using IMS.DataAccess.Context.EntityFramework;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfUserRepository : EfEntityRepositoryBase<User, InvoiceManagementDbContext>, IUserRepository
    {
        public EfUserRepository(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
