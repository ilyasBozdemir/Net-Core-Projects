namespace Application.ViewModels.Resident
{
    public class UpdateResidentViewModel
    {
        public Guid UserId { get; set; }
        public Guid HouseId { get; set; }
        public bool IsHirer { get; set; }
        public bool IsOwner { get; set; }
        public string CarPlate { get; set; }
    }
}
