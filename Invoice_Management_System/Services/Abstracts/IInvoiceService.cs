using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities;
using IMS.Business.Services;

namespace Services.Abstracts
{
    public interface IInvoiceService : IBaseCrudService<Invoice>
    {
        IDataResult<IEnumerable<InvoiceDto>> GetAllDetails();

        IDataResult<IEnumerable<InvoiceDto>> GetAllUserInvoiceDetail(int userId);
        IDataResult<InvoiceDto> GetByIdDetail(int id);
        IResult PaySuccess(int id);
    }
}
