using Domain.Common;

namespace Domain.Entities
{
    public class Log : BaseEntity
    {
        public override DateTime OlusturmaTarihi { get => base.OlusturmaTarihi; set => base.OlusturmaTarihi = value; }
        public override DateTime? GuncellemeTarihi { get => base.GuncellemeTarihi; set => base.GuncellemeTarihi = value; }
        public string Message { get; set; }
    }
}
