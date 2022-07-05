using Application.DTOs;
using Application.Utilities.Results;

namespace Services.Abstracts
{
    public interface IInvoicePaymentService
    {
        Task<IResult> PayInvoice(int userId, PayOrderDto payOrder);
    }
}
