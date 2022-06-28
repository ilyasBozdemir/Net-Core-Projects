using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfResidentDal : EfEntityRepositoryBase<Resident, InvoiceManagementDbContext>, IResidentRepository
    {
        public EfResidentDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<ResidentDto> GetAllDetails()
        {
            var result = from r in _context.Residents
                         join p in _context.Users on r.UserId equals p.Id
                         join h in _context.Houses on r.HouseId equals h.Id
                         join a in _context.Apartments on h.ApartmentId equals a.Id
                         select new ResidentDto()
                         {
                             UserId = r.UserId,
                             UserName = p.FullName,
                             House = $"{a.Name} no:{h.DoorNumber}",
                             CarPlate = r.CarPlate,
                             IsHirer = r.IsHirer,
                             IsOwner = r.IsOwner
                         };

            return result;
        }
    }
}
