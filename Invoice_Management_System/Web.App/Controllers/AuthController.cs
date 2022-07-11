using Application.Helpers;
using Application.ViewModels.Auth;
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
        public AuthController()
        {



        }

    }
}
