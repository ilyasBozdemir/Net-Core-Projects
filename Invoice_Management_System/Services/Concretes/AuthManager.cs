using Application.Helpers;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Utilities.Results;
using AutoMapper;
using Core.Utilities.Security.Hashing;
using Domain.Entities.Identity;
using Infrastructure.IdentitySettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

      
    }
}
