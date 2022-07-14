using Domain.Common;

namespace Domain.Entities
{
    public class Blok : BaseEntity
    {
        public string BlokAdi { get; set; }
        public short ToplamDaire { get; set; }
        public virtual ICollection<Daire> Daireler { get; set; }
    }
}
