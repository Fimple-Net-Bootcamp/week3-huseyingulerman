﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.Entities
{
    public class Food:BaseEntity    
    {
        public string Name { get; set; }
        public int Calory { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
