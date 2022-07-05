using Application.DTOs;
using Application.Utilities.Results;
using Domain.Entities;

namespace Services.Abstracts
{
    public interface IHouseService
    {
        IResult Create(House entity);
        IResult Delete(int id);
        IResult Update(int id, House entity);
        IDataResult<House> GetById(int id);
        IDataResult<IEnumerable<House>> GetAll();
        IDataResult<IEnumerable<HouseDto>> GetAllHouseDetail();
        IDataResult<HouseDto> GetHouseDetail(int id);

    }
}
