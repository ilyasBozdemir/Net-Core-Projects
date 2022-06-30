using AutoMapper;
using IMS.Business.Constants;
using IMS.Business.Services.Abstracts;
using IMS.Core.Utilities.Messages;
using IMS.Core.Utilities.Results;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Concretes
{
    public class HouseManager : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;
        public HouseManager(IHouseRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }
        public IResult Create(House entity)
        {
            var house = _houseRepository.Get(x =>
                x.ApartmentId == entity.ApartmentId && x.DoorNumber == entity.DoorNumber && x.Floor == entity.Floor);
            if (!(house == null))
                return new Result(false, Message.HouseAlreadyExist);

            var apartment = _houseRepository.GetApartment(entity.ApartmentId);
            if (apartment.TotalFloors < entity.Floor)
                return new Result(false, Message.HouseMoreFloors);

            _houseRepository.Add(entity);

            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.RegistrationFailed);
        }

        public IResult Delete(int id)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new Result(false, Message.HouseNotFound);
            _houseRepository.Delete(house);
            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.DataDeleted);
        }

        public IResult Update(int id, House entity)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new Result(false, Message.HouseNotFound);
            house.ApartmentId = entity.ApartmentId == default ? house.ApartmentId : entity.ApartmentId;
            house.DoorNumber = entity.DoorNumber == default ? house.DoorNumber : entity.DoorNumber;
            house.Floor = entity.Floor == default ? house.Floor : entity.Floor;
            house.FlatTypeId = entity.FlatTypeId == default ? house.FlatTypeId : entity.FlatTypeId;

            var apartment = _houseRepository.GetApartment(entity.ApartmentId);
            if (apartment.TotalFloors < entity.Floor)
                return new Result(false, Message.HouseMoreFloors);

            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.DataUpdated);

        }

        public IDataResult<House> GetById(int id)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new DataResult<House>(null, false, Message.HouseNotFound);
            return new DataResult<House>(house, true);
        }

        public IDataResult<IEnumerable<House>> GetAll()
        {
            var houses = _houseRepository.GetList();
            if (houses is null)
                return new DataResult<IEnumerable<House>>(null, false, Message.HouseNotFound);
            return new DataResult<IEnumerable<House>>(houses, true);
        }

        public IDataResult<IEnumerable<HouseDto>> GetAllHouseDetail()
        {
            var houses = _houseRepository.GetAllHouseDetail();
            if (houses is null)
                return new DataResult<IEnumerable<HouseDto>>(null, false, Message.HouseNotFound);
            return new DataResult<IEnumerable<HouseDto>>(houses, true);
        }

        public IDataResult<HouseDto> GetHouseDetail(int id)
        {
            var house = _houseRepository.GetHouseDetail(id);
            if (house is null)
                return new DataResult<HouseDto>(null, false, Message.HouseNotFound);
            return new DataResult<HouseDto>(house, true);
        }
    }
}
