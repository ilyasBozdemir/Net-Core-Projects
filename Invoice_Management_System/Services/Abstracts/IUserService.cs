using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities;
using IMS.Business.Services;
namespace Services.Abstracts
{
    public interface IUserService : IBaseCrudService<User>
    {
        IDataResult<UserDto> GetByIdUser(int id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<UserDto> GetByEmailUser(string email);
        IDataResult<IEnumerable<UserDto>> GetAllUser();
        IResult AddRefreshToken(int id, string refreshToken, DateTime expirationTime);
    }
}
