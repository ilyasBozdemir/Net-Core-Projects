using AutoMapper;
using IMS.Core.Utilities.Messages;
using IMS.Core.Utilities.Results;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using Services.Abstracts;
using System.Collections.Generic;

namespace IMS.Business.Services.Concretes
{
    public class InvoiceTypeManager : IInvoiceTypeService
    {
        private readonly IInvoiceTypeRespository _invoiceTypeRespository;
        private readonly IMapper _mapper;
        public InvoiceTypeManager(IInvoiceTypeRespository invoiceTypeRespository)
        {
            _invoiceTypeRespository = invoiceTypeRespository;
        }
        public InvoiceTypeManager(IInvoiceTypeRespository invoiceTypeRespository, IMapper mapper)
        {
            _invoiceTypeRespository = invoiceTypeRespository;
            _mapper = mapper;
        }
        public IResult Create(InvoiceType entity)
        {
            _invoiceTypeRespository.Add(entity);
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.RegistrationSuccessful);
        }

        public IResult Delete(int id)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new Result(false, Message.DataNotFound);
            _invoiceTypeRespository.Delete(invoiceType);
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.DataDeleted);
        }

        public IResult Update(int id, InvoiceType entity)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new Result(false, Message.DataNotFound);
            invoiceType.Name = entity.Name == default ? invoiceType.Name : entity.Name;
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.DataUpdated);
        }

        public IDataResult<InvoiceType> GetById(int id)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new DataResult<InvoiceType>(null, false, Message.DataNotFound);
            return new DataResult<InvoiceType>(invoiceType, true);
        }

        public IDataResult<IEnumerable<InvoiceType>> GetAll()
        {
            var invoiceTypes = _invoiceTypeRespository.GetList();
            return new DataResult<IEnumerable<InvoiceType>>(invoiceTypes, true);
        }
    }
}
