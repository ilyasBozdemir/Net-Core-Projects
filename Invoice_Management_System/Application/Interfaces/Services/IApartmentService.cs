using Application.Utilities.Results;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IApartmentService
    {
        IResult Create(Apartment entity);
        IResult Delete(Guid id);
        IResult Update(Guid id, Apartment entity);
        IDataResult<Apartment> GetById(Guid id);
        IDataResult<IEnumerable<Apartment>> GetAll();
    }
}
