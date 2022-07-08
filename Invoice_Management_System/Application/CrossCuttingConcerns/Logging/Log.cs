using Domain.Common;

namespace Application.CrossCuttingConcerns.Logging
{
    public class Log : BaseEntity
    {
        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = DateTime.Now; }
        }
        public override Guid Id 
        { 
            get; set;
        }
        public override DateTime UpdatedDate 
        { 
            get => base.UpdatedDate;
            set => base.UpdatedDate = value; 
        }
        public string Message { get; set; }

    }
}
