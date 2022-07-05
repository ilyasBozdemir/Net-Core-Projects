using Domain.Common;

namespace Application.DTOs
{
    public class HouseDto : BaseDTO
    {
        public override Guid Id { get; set; }
        public string ApartmentName { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string FlatType { get; set; }
    }
}
