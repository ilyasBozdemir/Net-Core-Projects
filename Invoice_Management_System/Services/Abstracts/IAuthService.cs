using Application.DTOs;
using Application.Utilities.Results;
using Application.Utilities.Security.Jwt;

namespace Services.Abstracts
{
    public interface IAuthService
    {
        IResult RegisterUser(RegisterDto registerUser);
        IDataResult<Token> LoginUser(LoginDto loginUser);
        IDataResult<UserDto> GetUserDtoByEmail(string email);
    }
}
