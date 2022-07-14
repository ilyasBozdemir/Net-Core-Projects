using Domain.Common;

namespace Domain.Entities
{
    public class Daire : BaseEntity
    {
        public short DaireNo { get; set; }
        public short Kat { get; set; }
        public bool BosMu { get; set; } = true;
        public string Tipi { get; set; }
        public bool? SahibiMi { get; set; }
        public Guid Blokid { get; set; }
        public virtual Blok Blok { get; set; }
    }
}
