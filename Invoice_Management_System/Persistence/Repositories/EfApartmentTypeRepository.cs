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
    public class EfApartmentTypeRepository : 
        EfEntityRepositoryBase<Apartment, IMSDbContext>, IApartmentTypeRepository
    {
        public EfApartmentTypeRepository(IMSDbContext context) : base(context)
        {
            
        }

        public ApartmentType Add(ApartmentType entity)
        {
       
            throw new NotImplementedException();
        }

        public void Delete(ApartmentType entity)
        {
            throw new NotImplementedException();
        }

        public ApartmentType Get(Expression<Func<ApartmentType, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<ApartmentType> GetAsync(Expression<Func<ApartmentType, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Expression<Func<ApartmentType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<ApartmentType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApartmentType> GetList(Expression<Func<ApartmentType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApartmentType>> GetListAsync(Expression<Func<ApartmentType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ApartmentType Update(ApartmentType entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<ApartmentType> IEntityRepository<ApartmentType>.Query()
        {
            throw new NotImplementedException();
        }
    }
}
