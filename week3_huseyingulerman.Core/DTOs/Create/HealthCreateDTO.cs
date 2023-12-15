using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.DTOs.Create
{
    public class HealthCreateDTO
    {
        public string Situation { get; set; }
        public int PetId { get; set; }
        public bool IsActive { get; set; }
    }
}
