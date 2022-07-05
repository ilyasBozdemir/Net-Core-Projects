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
    public class EfLogRepository : EfEntityRepositoryBase<Log, IMSDbContext>, ILogRepository
    {
        public EfLogRepository(IMSDbContext context) : base(context)
        {

        }
    }
}
