﻿using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfResidentRepository : EfEntityRepositoryBase<Resident, IMSDbContext>, IResidentRepository
    {
        public EfResidentRepository(IMSDbContext context) : base(context)
        {

        }
    }
}