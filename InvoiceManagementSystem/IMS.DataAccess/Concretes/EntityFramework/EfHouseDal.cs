using System.Collections.Generic;
using System.Linq;
using IMS.Core.DataAccess.EntityFramework;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;

namespace IMS.DataAccess.Concretes.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, InvoiceManagementDbContext>, IHouseRepository
    {
        public EfHouseDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<HouseDto> GetAllHouseDetail()
        {
            var result = from h in _context.Houses
                         join a in _context.Apartments on h.ApartmentId equals a.Id
                         join ft in _context.FlatTypes on h.FlatTypeId equals ft.Id
                         select new HouseDto
                         {
                             Id = h.Id,
                             ApartmentName = a.Name,
                             DoorNumber = h.DoorNumber,
                             Floor = h.Floor,
                             FlatType = $"{ft.RoomCount} + {ft.LivingRoomCount}"
                         };
            return result;
        }
        public HouseDto GetHouseDetail(int id)
        {
            var result = from h in _context.Houses
                         join a in _context.Apartments on h.ApartmentId equals a.Id
                         join ft in _context.FlatTypes on h.FlatTypeId equals ft.Id
                         where ft.Id == id
                         select new HouseDto
                         {
                             Id = h.Id,
                             ApartmentName = a.Name,
                             DoorNumber = h.DoorNumber,
                             Floor = h.Floor,
                             FlatType = $"{ft.RoomCount} + {ft.LivingRoomCount}"
                         };
            return result.SingleOrDefault();
        }

        public Apartment GetApartment(int apartmentId)
        {
            var result = from a in _context.Apartments
                         where a.Id == apartmentId
                         select new Apartment
                         {
                             Id = a.Id,
                             Name = a.Name,
                             TotalFloors = a.TotalFloors
                         };
            return result.SingleOrDefault();
        }
    }
}
