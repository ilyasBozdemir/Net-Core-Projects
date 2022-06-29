using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.CrossCuttingConcerns.Logging;
using IMS.Core.DataAccess;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;
namespace IMS.DataAccess.Abstracts
{
    public interface ILogRepository : IEntityRepository<Log>
    {
    }
}
