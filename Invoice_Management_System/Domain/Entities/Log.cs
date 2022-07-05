using Domain.Common;

namespace Domain.Entities
{
    public class Log : BaseEntity
    {
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
    }
}
