using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
