namespace Application.ViewModels.House
{
    public class GetHousesDetailViewModel
    {
        public Guid Id { get; set; }
        public string ApartmentName { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string ApartmentType { get; set; }
    }
}
