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
    public interface IResidentService : IBaseCrudService<Resident>
    {
        IDataResult<IEnumerable<ResidentDto>> GetAllDetails();
    }
}
