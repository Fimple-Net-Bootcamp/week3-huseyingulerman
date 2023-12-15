using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Repositories;

namespace week3_huseyingulerman.Repository.Repositories
{
    public class PetRepository : GenericRepository<Pet>,IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
