using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.Concrete
{
    public class FlatType : Core.Entities.Abstracts.IEntity
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public int LivingRoomCount { get; set; }

    }
}
