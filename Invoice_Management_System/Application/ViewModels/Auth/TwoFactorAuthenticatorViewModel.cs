using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public class TwoFactorAuthenticatorViewModel
    {
        public string SharedKey { get; set; } = default!;
        public string AuthenticationUri { get; set; } = default!;
        public string VerificationCode { get; set; } = default!;
    }
}
