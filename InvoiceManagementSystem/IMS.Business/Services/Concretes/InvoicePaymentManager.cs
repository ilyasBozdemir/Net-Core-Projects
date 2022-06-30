

using AutoMapper;
using IMS.Business.Constants;
using IMS.Business.Services.Abstracts;
using IMS.Business.Services.CreditCardService.PaymentAPI.Abstracts;
using IMS.Business.Services.CreditCardService.PaymentService;
using IMS.Core.Utilities.Messages;
using IMS.Core.Utilities.Results;
using IMS.DataAccess.Abstracts;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Business.Services.Concretes
{
    public class InvoicePaymentManager : IInvoicePaymentService
    {
        private readonly IInvoicePaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoicePaymentManager(IInvoicePaymentRepository paymentRepository, IPaymentService paymentService, IInvoiceService invoiceService, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _paymentService = paymentService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public async Task<IResult> PayInvoice(int userId, PayOrderDto payOrder)
        {
            PaymentOrder paymentOrder = _mapper.Map<PaymentOrder>(payOrder);
            var psResult = await _paymentService.PayOrder(paymentOrder);
            if (!psResult.Status)
            {
                return new Result(psResult.Status, $"{psResult.StatusCode} - {psResult.Message}");
            }
            InvoicePayment pip = new InvoicePayment
            {
                UserId = userId,
                InvoiceId = payOrder.InvoiceId,
                PayingAmount = payOrder.Amount
            };
            _paymentRepository.Add(pip);
            var result = _paymentRepository.SaveChanges();
            if (result == 0)
                return new Result( false,Message.DatabasePaySaveError);

            var inResult = _invoiceService.PaySuccess(payOrder.InvoiceId);
            if (!inResult._success)
                return new Result( false, Message.InvoiceSaveError);
            return new Result(psResult.Status, psResult.Message);

        }

        public IDataResult<InvoicePayment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<InvoicePayment>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
