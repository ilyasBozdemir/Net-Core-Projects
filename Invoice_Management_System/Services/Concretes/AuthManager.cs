using Application.Helpers;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Utilities.Results;
using Application.ViewModels.Auth;
using AutoMapper;
using Core.Utilities.Security.Hashing;
using Domain.Entities.Identity;
using Infrastructure.IdentitySettings;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly EmailHelper _emailHelper;
        private readonly TwoFactorAuthenticationService _twoFactorAuthService;

        public IResult CreateUser(SignUpViewModel viewModel)
        {
            #region Register

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(viewModel.Password, out passwordHash, out passwordSalt);

            var appUser = new AppUser()
            {
                UserName = viewModel.UserName,
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                PasswordHash = Encoding.ASCII.GetString(passwordHash),
                PasswordSalt = Encoding.ASCII.GetString(passwordSalt),
                PhoneNumber = viewModel.PhoneNumber,
                Email = viewModel.Email,
                Gender = viewModel.Gender,
                BirthDay = viewModel.BirthDay,
                TwoFactorType = Domain.Enums.TwoFactorType.None,
                CreatedOn = DateTime.UtcNow,
            };


            //IdentityResult ıdentityResult = await _userManager.CreateAsync(appUser, viewModel.Password);



            #endregion
            throw new NotImplementedException();
        }
    }
}
