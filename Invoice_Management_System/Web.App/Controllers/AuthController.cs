using Application.Helpers;
using Application.Interfaces.Services;
using Application.ViewModels.Auth;
using AutoMapper;
using Core.Utilities.Security.Hashing;
using Domain.Entities.Identity;
using Domain.Enums;
using Infrastructure.IdentitySettings;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace Web.App.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IAuthService  _authService;
        private readonly IMapper _mapper;


        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost, /*Authorize(Roles = OperationClaims.Anonymous)*/]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(SignUpViewModel viewModel)
        {
            #region Register

            if (ModelState.IsValid)
            {
                var result = _authService.CreateUser(viewModel);

            }
            return View();

            #endregion
        }
    }
}
