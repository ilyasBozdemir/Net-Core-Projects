using Domain.Common;

namespace Domain.Entities
{
    public class Fatura : BaseEntity
    {
        public DateTime SonOdemeTarihi { get; set; }
        public string FaturaAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }

        public ICollection<UserFatura> UserFaturaList { get; set; }

    }
}
