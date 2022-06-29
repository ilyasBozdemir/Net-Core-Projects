using IMS.Core.Utilities.Results;
using IMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
{
    public interface ApartmentTypeService
    {
        IResult Create(ApartmentType entity);
        IResult Delete(int id);
        IResult Update(int id, ApartmentType entity);
        IDataResult<ApartmentType> GetById(int id);
        IDataResult<IEnumerable<ApartmentType>> GetAll();
    }
}
