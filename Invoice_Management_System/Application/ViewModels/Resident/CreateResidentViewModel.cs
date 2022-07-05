namespace Application.ViewModels.Resident
{
    public class CreateResidentViewModel
    {
        public Guid UserId { get; set; }
        public int HouseId { get; set; }
        public bool IsHirer { get; set; }
        public bool IsOwner { get; set; }
        public string CarPlate { get; set; }
    }
}
