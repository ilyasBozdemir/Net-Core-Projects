﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Apartment:BaseEntity
    {
        public override Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalFloors { get; set; }
        public string Block { get; set; }
      
    }
}