using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfUserRepository : EfEntityRepositoryBase<User, IMSDbContext>, IUserRepository
    {
        public EfUserRepository(IMSDbContext context) : base(context)
        {

        }
    }
}
