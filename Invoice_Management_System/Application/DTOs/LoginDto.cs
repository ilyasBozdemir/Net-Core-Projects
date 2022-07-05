using Domain.Common;

namespace Application.DTOs
{
    public class LoginDto : BaseDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
