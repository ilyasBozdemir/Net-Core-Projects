using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApartmentType : BaseEntity
    {
        public override Guid Id { get; set; }
        public int RoomCount { get; set; }
        public int LivingRoomCount { get; set; }
    }
}
