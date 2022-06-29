using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.DataAccess;
using IMS.Entities.Concrete;
namespace IMS.DataAccess.Abstracts
{
    public interface IApartmentTypeRepository : IEntityRepository<ApartmentType>
    {
    }
}
