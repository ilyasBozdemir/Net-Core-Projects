using System;
using AutoMapper;
using IMS.Business.Constants;
using IMS.Business.Services.Abstracts;
using IMS.Core.Entities.Concretes;
using IMS.Core.Utilities.Hashing;
using IMS.Core.Utilities.Results;
using IMS.Core.Utilities.Security.JWT;
using IMS.DataAccess.Abstracts;
using IMS.Entities.DTOs;
using Microsoft.Extensions.Configuration;

namespace IMS.Business.Services.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthManager(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public IResult RegisterUser(RegisterDto registerUser)
        {
            byte[] passwordHash, passwordSalt;

            var user = _userService.GetByEmail(registerUser.Email).Data;
            if (!(user == null))
                return new Result(false, Message.UserAlreadyExist);
            HashingHelper.CreatePasswordHash(registerUser.Password, out passwordSalt, out passwordHash);
            user = new User
            {
                FullName = registerUser.FullName,
                Email = registerUser.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };
            var result = _userService.Create(user);
            if (!result.Success)
                return new Result(false, Message.RegistrationSuccessful);
            return new Result(true, Message.RegistrationFailed);


        }

        public IDataResult<Token> LoginUser(LoginDto loginUser)
        {
            var user = _userService.GetByEmail(loginUser.Email).Data;
            if (user is null)
                return new DataResult<Token>(null, false, Message.UserNotFound);
            if (!HashingHelper.VerifyPasswordHash(loginUser.Password, user.PasswordSalt, user.PasswordHash))
                return new DataResult<Token>(null, false, Message.WrongPassword);
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);
            _userService.AddRefreshToken(user.Id, token.RefreshToken, token.Expiration.AddMinutes(5));
            return new DataResult<Token>(token, true);
        }

        public IDataResult<UserDto> GetUserDtoByEmail(string email)
        {
            var result = _userService.GetByEmailUser(email);
            if (!result.Success)
                return new DataResult<UserDto>(null, false, Message.UserNotFound);
            return result;
        }

        IDataResult<Token> IAuthService.LoginUser(LoginDto loginUser)
        {
            throw new NotImplementedException();
        }
    }
}
