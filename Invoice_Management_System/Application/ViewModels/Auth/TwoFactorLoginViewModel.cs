using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public class TwoFactorLoginViewModel
    {
        public string VerificationCode { get; set; } = default!;
        public bool IsRecoveryCode { get; set; }
        public TwoFactorType TwoFactorType { get; set; }
    }
}
