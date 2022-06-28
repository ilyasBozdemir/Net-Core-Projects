using IMS.Core.DataAccess;
using IMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Abstracts
{
    public interface IApartmentRepository : IEntityRepository<Apartment>
    {
    }
}
