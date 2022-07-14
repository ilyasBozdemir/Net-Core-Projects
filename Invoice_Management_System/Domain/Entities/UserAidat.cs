using Domain.Common;
namespace Domain.Entities
{
    public class UserAidat : BaseEntity
    {
        public Guid KullaniciId { get; set; }
        public Guid AidatId { get; set; }
        public User User { get; set; }
        public Aidat Aidat { get; set; }
        public bool OdendiMi { get; set; } = false;
        public DateTime? OdenmeTarihi { get; set; }
    }
}
