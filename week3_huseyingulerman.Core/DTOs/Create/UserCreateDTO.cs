using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.DTOs.Create
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
    }
}
