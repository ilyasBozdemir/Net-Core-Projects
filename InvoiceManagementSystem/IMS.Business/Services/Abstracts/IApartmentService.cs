using IMS.Core.Utilities.Results;
using IMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
{
    public interface IApartmentService
    {
        IResult Create(Apartment entity);
        IResult Delete(int id);
        IResult Update(int id, Apartment entity);
        IDataResult<Apartment> GetById(int id);
        IDataResult<IEnumerable<Apartment>> GetAll();
    }
}
