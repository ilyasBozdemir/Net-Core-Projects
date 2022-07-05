using AutoMapper;
using IMS.Core.Entities.Concretes;
using IMS.Core.Utilities.Results;
using IMS.DataAccess.Abstracts;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.Utilities.Messages;
using Services.Abstracts;

namespace IMS.Business.Services.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IResult Create(User user)
        {
            _userRepository.Add(user);
            int result = _userRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.RegistrationFailed);
            return new Result(true, Message.RegistrationSuccessful);
        }

        public IResult Delete(int id)
        {
            //var resident = _residentRepository.Get(x => x.UserId == id);
            //if (resident is null)
            //    return new Result(false, Message.UserNotFound);
            //_residentRepository.Delete(resident);
            //var result = _residentRepository.SaveChanges();
            //if (result == 0)
            //    return new Result(false, Message.DatabaseSaveError);
            //return new Result(true, Message.DataDeleted);

            throw new NotImplementedException();
        }

        public IResult Update(int id, User entity)
        {
            User user = _userRepository.Get(x => x.Id == id);
            if (user is null)
                return new Result(false, Message.UserNotFound);
            user.Email = entity.Email == default ? user.Email : entity.Email;
            user.CitizenId = entity.CitizenId == default ? user.CitizenId : entity.CitizenId;
            user.FullName = entity.FullName == default ? user.FullName : entity.FullName;
            user.PhoneNumber = entity.PhoneNumber == default ? user.PhoneNumber : entity.PhoneNumber;
            user.IsActive = entity.IsActive == default ? user.IsActive : entity.IsActive;
            var result = _userRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.UpdatedFailed);
            return new Result(true, Message.UpdatedSuccessful);
        }

        public IDataResult<User> GetById(int id)
        {
            User user = _userRepository.Get(x => x.Id == id);
            if (user is null)
                return new DataResult<User>(null, false, Message.UserNotFound);
            return new DataResult<User>(user, true);
        }

      

        public IResult AddRefreshToken(int id, string refreshToken, DateTime expirationTime)
        {
            var user = _userRepository.Get(x => x.Id == id);
            user.RefreshToken = refreshToken;
            user.RefresTokenExpireDate = expirationTime;
            int result = _userRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.RegistrationFailed);
            return new Result(true, Message.RegistrationSuccessful);
        }

        public IDataResult<IEnumerable<User>> GetAll()
        {
            var data = _userRepository.GetList();
            return new DataResult<IEnumerable<User>>(data, true);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            User user = _userRepository.Get(x => x.Email == email);
            if (user is null)
                return new DataResult<User>(null, false, Message.UserNotFound);
            return new DataResult<User>(user, true);
        }


        IDataResult<UserDto> IUserService.GetByIdUser(int id)
        {
            User user = _userRepository.Get(x => x.Id == id);
            if (user is null)
                return new DataResult<UserDto>(null, false, Message.UserNotFound);
            UserDto rtnObj = _mapper.Map<UserDto>(user);
            return new DataResult<UserDto>(rtnObj, true);
        }

        IDataResult<UserDto> IUserService.GetByEmailUser(string email)
        {
            User user = _userRepository.Get(x => x.Email == email);
            if (user is null)
                return new DataResult<UserDto>(null, false, Message.UserNotFound);
            UserDto rtnObj = _mapper.Map<UserDto>(user);
            return new DataResult<UserDto>(rtnObj, true);
        }

        IDataResult<IEnumerable<UserDto>> IUserService.GetAllUser()
        {
            var data = _userRepository.GetList();
            var rtnObj = _mapper.Map<IEnumerable<UserDto>>(data);
            return new DataResult<IEnumerable<UserDto>>(rtnObj, true);
        }
    }
}
