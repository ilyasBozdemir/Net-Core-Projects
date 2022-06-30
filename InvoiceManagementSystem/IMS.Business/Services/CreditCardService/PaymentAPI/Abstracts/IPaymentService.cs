using IMS.Business.Services.CreditCardService.PaymentService;
using IMS.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.CreditCardService.PaymentAPI.Abstracts
{
    public interface IPaymentService
    {
        Task<PaymentResult> PayOrder(PaymentOrder payOrder);
        Task<IDataResult<object>> CompanyAllPayOrder();

    }
}
