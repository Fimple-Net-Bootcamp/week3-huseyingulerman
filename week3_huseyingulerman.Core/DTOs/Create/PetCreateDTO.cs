using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.DTOs.Create
{
    public class PetCreateDTO
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string AppUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
