using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TwoFactorType : byte
    {
        None,
        Sms,
        Email,
        Microsoft_Authenticator,
        Google_Authenticator,
        My_Authenticator/*kendimin yazacağı Authenticator(Doğrulayıcı) servisi*/
    }
}
