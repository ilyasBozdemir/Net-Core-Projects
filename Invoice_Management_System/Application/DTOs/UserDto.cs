using Domain.Common;

namespace Application.DTOs
{
    public class UserDto : BaseDTO
    {
        public override Guid Id { get; set; }
        public string FullName { get; set; }
        public long CitizenId { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
