using IMS.Core.Utilities.Results;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Services.Abstracts
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
