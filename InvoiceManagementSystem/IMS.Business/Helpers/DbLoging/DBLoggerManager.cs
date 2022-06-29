using IMS.Core.CrossCuttingConcerns.Logging;
using IMS.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Helpers.DbLoging
{
    public class DBLoggerManager : ILoggerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DBLoggerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Log(string message)
        {
            _unitOfWork.Logs.Add(new Log { Message = message });
            _unitOfWork.Logs.SaveChanges();
        }
    }
}
