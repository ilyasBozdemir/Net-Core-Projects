using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Log : BaseEntity
    {
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public string IpAdresi { get; set; }

    }
}
