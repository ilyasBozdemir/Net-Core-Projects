using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntity
    {
        public delegate bool EntityDeletedEvent(IEntity entity);
        public event EntityDeletedEvent Deleted;

        public delegate bool EntityInsertedEvent(IEntity entity);
        public event EntityInsertedEvent Inserted;

        public delegate bool EntityUpdatedEvent(IEntity entity);
        public event EntityDeletedEvent Updated;
    }
}
