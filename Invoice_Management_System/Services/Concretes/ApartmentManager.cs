using Application.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Application.Interfaces.UnitOfWork;
using Application.Utilities.Results;
using Application.Validators.FluentValidation;
using AutoMapper;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Domain.Entities;
using Infrastructure.Messages.Messages;
using Services.Abstracts;

namespace IMS.Business.Services.Concretes
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApartmentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /*kullanım örneği...*/
        [LogAspect(typeof(DatabaseLogger))]
        [ValidationAspect(typeof(ApartmentValidator), Priority = 1)]
        [CacheRemoveAspect("IApartmentService.Get")]
        public IResult Create(Apartment createApartment)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Name == createApartment.Name);
            if (!(apartment == null))
                return new Result(false, Message.ApartmentAlreadyExist);
            apartment = _mapper.Map<Apartment>(createApartment);
            _unitOfWork.Apartments.Add(apartment);
            int result = _unitOfWork.Apartments.SaveChanges();
            if (result == 0)
                return new Result(false, Message.RegistrationFailed);
            return new Result(true, Message.RegistrationSuccessful);
        }
        public IResult Delete(Guid id)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Id == id);
            if (apartment is null)
                return new Result(false, Message.ApartmentNotFound);
            _unitOfWork.Apartments.Delete(apartment);
            int result = _unitOfWork.Apartments.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true);
        }

       

        public IDataResult<IEnumerable<Apartment>> GetAll()
        {
            var apartments = _unitOfWork.Apartments.GetList();
            return new DataResult<IEnumerable<Apartment>>(apartments, true);
            throw new Exception();
        }
        public IDataResult<Apartment> GetById(Guid id)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Id == id);
            if (apartment is null)
                return new DataResult<Apartment>(null, false, Message.ApartmentNotFound);
            return new DataResult<Apartment>(apartment, true);
        }

        public IResult Update(Guid id, Apartment updateApartment)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Id == id);
            if (apartment is null)
                return new Result(false, Message.ApartmentNotFound);
            apartment.Name = updateApartment.Name == default ? apartment.Name : updateApartment.Name;
            apartment.TotalFloors = updateApartment.TotalFloors == default 
                ? apartment.TotalFloors : updateApartment.TotalFloors;

            int result = _unitOfWork.Apartments.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.RegistrationSuccessful);
        }
    }
}
