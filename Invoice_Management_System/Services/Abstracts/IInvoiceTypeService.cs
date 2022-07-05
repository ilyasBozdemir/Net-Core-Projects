using Application.Utilities.Results;
using Domain.Entities;

namespace Services.Abstracts
{
    public interface IInvoiceTypeService
    {
        IResult Create(InvoiceType entity);
        IResult Delete(int id);
        IResult Update(int id, InvoiceType entity);
        IDataResult<InvoiceType> GetById(int id);
        IDataResult<IEnumerable<InvoiceType>> GetAll();
    }
}
