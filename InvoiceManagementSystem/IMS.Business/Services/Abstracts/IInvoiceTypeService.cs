using IMS.Core.Utilities.Results;
using IMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
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
