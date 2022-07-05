using Application.Utilities.Results;
using Domain.Entities;

namespace Services.Abstracts
{
    public interface IApartmentTypeService
    {
        IResult Create(ApartmentType entity);
        IResult Delete(int id);
        IResult Update(int id, ApartmentType entity);
        IDataResult<ApartmentType> GetById(int id);
        IDataResult<IEnumerable<ApartmentType>> GetAll();
    }
}
