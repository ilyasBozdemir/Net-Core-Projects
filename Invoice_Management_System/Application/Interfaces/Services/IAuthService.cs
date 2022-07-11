using Application.Utilities.Results;
using Application.ViewModels.Auth;
using Domain.Entities.Identity;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        IResult CreateUser(SignUpViewModel viewModel);
        //bool ExistUser(AppUser appUser);
        //IResult Login();
        //IResult TwoFactorLogin();
        //IResult ChangePassword();
        //IResult ForgotPassword();
        //IResult ResetPassword();
        //IResult ConfirmEmail();
        //IResult TwoFactorType();
        //IResult TwoFactorAuthenticator();
        //IResult FacebookLogin();
        //IResult TwitterLogin();
        //IResult GoogleLogin();
        //IResult MicrosoftLogin();
        //IResult FacebookLoginCallback();
        //IResult TwitterLoginCallback();
        //IResult GoogleLoginCallback();
        //IResult MicrosoftLoginCallback();
        //IResult ExternalResponse();

    }
}
