using AutoMapper;
using IMS.Core.Utilities.Messages;
using IMS.Core.Utilities.Results;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Concretes
{
    public class ApartmentTypeManager : IApartmentTypeService
    {
        private readonly IApartmentTypeRepository _apartmentTypeRepository;
        private readonly IMapper _mapper;
        public ApartmentTypeManager(IApartmentTypeRepository flatTypeRepository, IMapper mapper)
        {
            _apartmentTypeRepository = flatTypeRepository;
            _mapper = mapper;

        }
        public IResult Create(ApartmentType entity)
        {
            var flatType = _apartmentTypeRepository.Get(x => x.RoomCount == entity.RoomCount && x.LivingRoomCount == entity.LivingRoomCount);
            if (!(flatType == null))
                return new Result(false,Message.ApartmentTypeAlreadyExist);
            _apartmentTypeRepository.Add(entity);
            var result = _apartmentTypeRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.RegistrationFailed);
            return new Result( true, Message.RegistrationSuccessful);

        }

        public IResult Delete(int id)
        {
            var flatType = _apartmentTypeRepository.Get(x => x.Id == id);
            if (flatType is null)
                return new Result(false, Message.ApartmentTypeNotFound);
            _apartmentTypeRepository.Delete(flatType);
            var result = _apartmentTypeRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.RegistrationFailed);
            return new Result(true, Message.RegistrationSuccessful);
        }

        public IDataResult<IEnumerable<ApartmentType>> GetAll()
        {
            var flatTypes = _apartmentTypeRepository.GetList();
            return new DataResult<IEnumerable<ApartmentType>>(flatTypes, true);
        }

        public IDataResult<ApartmentType> GetById(int id)
        {
            var flatType = _apartmentTypeRepository.Get(x => x.Id == id);
            if (flatType is null)
                return new DataResult<ApartmentType>(null, false, Message.ApartmentTypeNotFound);
            return new DataResult<ApartmentType>(flatType, true);
        }

        public IResult Update(int id, ApartmentType entity)
        {
            var flatType = _apartmentTypeRepository.Get(x => x.Id == id);
            if (flatType is null)
                return new DataResult<ApartmentType>(null, false, Message.ApartmentTypeNotFound);
            flatType.RoomCount = entity.RoomCount == default ? flatType.RoomCount : entity.RoomCount;
            flatType.LivingRoomCount = entity.LivingRoomCount == default ? flatType.LivingRoomCount : entity.LivingRoomCount;
            var result = _apartmentTypeRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.RegistrationFailed);
            return new Result(true, Message.RegistrationSuccessful);

        }
    }
}
