using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs.Create;

namespace week3_huseyingulerman.Core.DTOs.Update
{
    public class PetUpdateDTO:PetCreateDTO
    {
        public int Id { get; set; }
    }
}
