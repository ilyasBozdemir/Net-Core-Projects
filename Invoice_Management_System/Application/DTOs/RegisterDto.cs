using Domain.Common;
namespace Application.DTOs
{
    public class RegisterDto : BaseDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
