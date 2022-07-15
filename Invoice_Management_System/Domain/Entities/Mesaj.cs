using Domain.Common;
using Domain.Enums;
namespace Domain.Entities
{
    public class Mesaj : BaseEntity
    {
        public Guid Kimden { get; set; }
        public Guid Kime { get; set; }
        public string Baslik { get; set; }
        public MesajTuru MesajTuru { get; set; }
        public string MesajIcerik { get; set; }
        public bool OnaylandiMi { get; set; }
        public bool OkunduMu { get; set; }
    }
}

