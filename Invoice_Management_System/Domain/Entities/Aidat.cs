using Domain.Common;

namespace Domain.Entities
{
    public class Aidat : BaseEntity
    {
        public string Donem { get; set; }
        public decimal Tutar { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public string Aciklama { get; set; }

        public ICollection<UserAidat> UserAidats { get; set; }

    }
}
