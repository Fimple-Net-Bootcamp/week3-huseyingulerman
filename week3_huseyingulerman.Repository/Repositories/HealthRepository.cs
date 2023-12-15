using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Repositories;

namespace week3_huseyingulerman.Repository.Repositories
{
    public class HealthRepository : GenericRepository<Health>,IHealthRepository
    {
    
        public HealthRepository(AppDbContext context) : base(context)
        {
        
        }

        public async Task<Health> GetHealtyByPetId(int id)
        {
       return await _context.Healths.Where(x=>x.PetId == id).FirstOrDefaultAsync();
        }
    }
}
