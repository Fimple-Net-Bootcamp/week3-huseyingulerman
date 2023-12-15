using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.DTOs
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetId { get; set; }
        public bool IsActive { get; set; }
        
    }
}
