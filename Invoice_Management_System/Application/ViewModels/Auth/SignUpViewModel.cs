using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public class SignUpViewModel
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Gender Gender { get; set; } = Gender.Unknown;
        public DateTime BirthDay { get; set; }
        public string Password { get; set; } = default!;
    }
}
