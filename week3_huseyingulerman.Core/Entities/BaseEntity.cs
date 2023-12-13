using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Enums;
using week3_huseyingulerman.Core.Interfaces;

namespace week3_huseyingulerman.Core.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get ; set; }
        public bool IsActive { get ; set; }
        public Status Status { get ; set ; }
        public DateTime CreatedDate { get ; set; }
        public DateTime? ModifiedDate { get ; set; }
        public DateTime? DeletedDate { get ; set ; }
    }
}
