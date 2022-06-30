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
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceManager(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public IResult Create(Invoice entity)
        {
            _invoiceRepository.Add(entity);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result(false,Message.DatabaseSaveError);
            return new Result(true, Message.RegistrationSuccessful);
        }

        public IResult Delete(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result(false, Message.InvoiceNotFound);
            _invoiceRepository.Delete(invoice);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(true, Message.InvoiceDeleted);
        }

        public IResult Update(int id, Invoice entity)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result(false, Message.InvoiceNotFound);

            invoice.HouseId = entity.HouseId == default ? invoice.HouseId : entity.HouseId;
            invoice.InvoiceTypeId = entity.InvoiceTypeId == default ? invoice.InvoiceTypeId : entity.InvoiceTypeId;
            invoice.Amount = entity.Amount == default ? invoice.Amount : entity.Amount;
            invoice.InvoiceDate = entity.InvoiceDate == default ? invoice.InvoiceDate : entity.InvoiceDate;
            invoice.Status = entity.Status == default ? invoice.Status : entity.Status;

            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(false, Message.InvoiceUpdated);
        }

        public IDataResult<Invoice> GetById(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new DataResult<Invoice>(null, false, Message.InvoiceNotFound);
            return new DataResult<Invoice>(invoice, true);
        }

        public IDataResult<IEnumerable<Invoice>> GetAll()
        {
            var invoices = _invoiceRepository.GetList();
            return new DataResult<IEnumerable<Invoice>>(invoices, true);
        }

        public IDataResult<IEnumerable<InvoiceDto>> GetAllDetails()
        {
            var invoices = _invoiceRepository.GetAllInvoiceDetail();
            return new DataResult<IEnumerable<InvoiceDto>>(invoices, true);
        }

        public IDataResult<IEnumerable<InvoiceDto>> GetAllUserInvoiceDetail(int userId)
        {
            var invoices = _invoiceRepository.GetAllUserInvoiceDetail(userId);
            return new DataResult<IEnumerable<InvoiceDto>>(invoices, true);
        }

        public IDataResult<InvoiceDto> GetByIdDetail(int id)
        {
            var invoice = _invoiceRepository.GetInvoiceDetail(id);
            if (invoice is null)
                return new DataResult<InvoiceDto>(null, false, Message.InvoiceNotFound);
            return new DataResult<InvoiceDto>(invoice, true);
        }

        public IResult PaySuccess(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result(false, Message.InvoiceNotFound);

            invoice.Status = false;

            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result(false, Message.DatabaseSaveError);
            return new Result(false, Message.InvoicePay);
        }
    }
}
