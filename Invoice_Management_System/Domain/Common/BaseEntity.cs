using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity: IEntity
    {
        virtual public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }

        public event IEntity.EntityDeletedEvent Deleted;
        public event IEntity.EntityInsertedEvent Inserted;
        public event IEntity.EntityDeletedEvent Updated;
    }
}
