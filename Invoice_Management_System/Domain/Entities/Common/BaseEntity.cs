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
        public bool AktifMi { get; set; } = true;
        public virtual DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public virtual DateTime? GuncellemeTarihi { get; set; }

        public event IEntity.EntityDeletedEvent Deleted;
        public event IEntity.EntityInsertedEvent Inserted;
        public event IEntity.EntityDeletedEvent Updated;
    }
}
