using Application.Repositories;
using Domain.Common;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfHouseRepository : EfEntityRepositoryBase<House, IMSDbContext>, IHouseRepository
    {
        public EfHouseRepository(IMSDbContext context) : base(context)
        {
            
        }
    }
}
