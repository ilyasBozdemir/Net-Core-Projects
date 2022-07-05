using System.Web.Mvc;
namespace Application.ViewModels.House
{
    public class CreateHouseViewModel
    {
        public Guid ApartmentId { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public Guid ApartmentTypeId { get; set; }
        public IEnumerable<SelectListItem> Apartments { get; set; }
        public IEnumerable<SelectListItem> FlatTypes { get; set; }

    }
}
