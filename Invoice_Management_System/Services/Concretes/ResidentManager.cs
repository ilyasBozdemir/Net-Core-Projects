using AutoMapper;
using IMS.Core.Utilities.Messages;
using IMS.Core.Utilities.Results;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Concretes
{
    public class ResidentManager : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public ResidentManager(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }
        public IResult Create(Resident entity)
        {
            entity.CarPlate.ToUpper();
            _residentRepository.Add(entity);
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.RegistrationSuccessful);
        }

        public IResult Delete(int id)
        {
            var resident = _residentRepository.Get(x => x.UserId == id);
            if (resident is null)
                return new Result(false, Message.UserNotFound);
            _residentRepository.Delete(resident);
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.DataDeleted);
        }

        public IResult Update(int id, Resident entity)
        {
            var resident = _residentRepository.Get(x => x.UserId == id);
            if (resident is null)
                return new Result(false, Message.UserNotFound);

            resident.HouseId = entity.HouseId == default ? resident.HouseId : entity.HouseId;
            resident.CarPlate = entity.CarPlate == default ? resident.CarPlate : entity.CarPlate.ToUpper();
            resident.IsHirer = entity.IsHirer == default ? resident.IsHirer : entity.IsHirer;
            resident.IsOwner = entity.IsOwner == default ? resident.IsOwner : entity.IsOwner;
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.DataUpdated);
        }

        public IDataResult<Resident> GetById(int id)
        {
            var resident = _residentRepository.Get(x => x.UserId == id);
            if (resident is null)
                return new DataResult<Resident>(null, false, Message.UserNotFound);
            return new DataResult<Resident>(resident, true);
        }

        public IDataResult<IEnumerable<Resident>> GetAll()
        {
            var residents = _residentRepository.GetList();
            return new DataResult<IEnumerable<Resident>>(residents, true);
        }

        public IDataResult<IEnumerable<ResidentDto>> GetAllDetails()
        {
            var residents = _residentRepository.GetAllDetails();
            return new DataResult<IEnumerable<ResidentDto>>(residents, true);
        }
    }
}
