using static Domain.Common.IEntity;
namespace Domain.Common
{
    public class BaseEntity: IEntity
    {
        virtual public Guid Id { get; set; }
        public bool AktifMi { get; set; } = true;
        public virtual DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public virtual DateTime? GuncellemeTarihi { get; set; }

        public event EntityDeletedEvent? Deleted;
        public event EntityInsertedEvent? Inserted;
        public event EntityDeletedEvent? Updated;
    }
}
