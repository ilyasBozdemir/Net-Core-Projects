using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Infrastructure.IdentitySettings
{
    public class TwoFactorAuthenticationService
    {
        private readonly UrlEncoder _urlEncoder;

        public TwoFactorAuthenticationService(UrlEncoder urlEncoder)
        {
            _urlEncoder = urlEncoder;
        }

        public string GenerateQrCodeUri(string email, string authenticatorKey)
        {
            var encodedUrl = _urlEncoder.Encode("www.localhost.com");
            var encodedEmail = _urlEncoder.Encode(email);

            return $"otpauth://totp/{encodedUrl}:{encodedEmail}?secret={authenticatorKey}&issuer={encodedUrl}&digits=6";
        }
    }
}
