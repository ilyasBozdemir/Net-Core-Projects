using IMS.Core.Entities.Concretes;
using IMS.Core.Utilities.Results;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
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
