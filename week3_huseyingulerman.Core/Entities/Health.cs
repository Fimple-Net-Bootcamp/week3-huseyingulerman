using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.Entities
{
    public class Health:BaseEntity
    {
        public string Situation { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }

    }
}
