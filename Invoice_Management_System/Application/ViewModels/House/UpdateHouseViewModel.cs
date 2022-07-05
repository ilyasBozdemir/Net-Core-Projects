namespace Application.ViewModels.House
{
    public class UpdateHouseViewModel
    {
        public Guid Id { get; set; }
        public Guid ApartmentId { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public Guid ApartmentTypeId { get; set; }
    }
}
