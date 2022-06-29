using IMS.Core.Utilities.Results;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
{
    public interface IInvoicePaymentService
    {
        Task<IResult> PayInvoice(int userId, PayOrderDto payOrder);
    }
}
