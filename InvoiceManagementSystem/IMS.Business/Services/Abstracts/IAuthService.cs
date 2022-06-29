using IMS.Core.Utilities.Results;
using IMS.Core.Utilities.Security.JWT;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
{
    public interface IAuthService
    {
        IResult RegisterUser(RegisterDto registerUser);
        IDataResult<Token> LoginUser(LoginDto loginUser);
        IDataResult<UserDto> GetUserDtoByEmail(string email);
    }
}
