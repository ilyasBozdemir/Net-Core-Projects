using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities;
using IMS.Business.Services;

namespace Services.Abstracts
{
    public interface IResidentService : IBaseCrudService<Resident>
    {
        IDataResult<IEnumerable<ResidentDto>> GetAllDetails();
    }
}
