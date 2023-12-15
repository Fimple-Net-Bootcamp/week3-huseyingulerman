using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Enums;

namespace week3_huseyingulerman.Core.Entities
{
    public class AppUser:IdentityUser
    {

        public string FİrstName { get; set; }
        public string LastName { get; set; }
      
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Pet> Pets { get; set; }

    }
}
