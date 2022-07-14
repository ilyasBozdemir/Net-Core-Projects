using Domain.Common;

namespace Domain.Entities
{
    public class UserFatura : BaseEntity
    {
        public Guid KullaniciId { get; set; }
        public Guid FaturaId { get; set; }
        public User User { get; set; }
        public Fatura Fatura { get; set; }

        public bool OdendiMi { get; set; } = false;
        public DateTime? OdemeTarihi { get; set; }
    }
}
