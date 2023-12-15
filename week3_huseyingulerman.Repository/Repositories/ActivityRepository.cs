using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Repositories;

namespace week3_huseyingulerman.Repository.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddActivityByPetId(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public async Task<List<Activity>> GetActivityByPetId(int id)
        {
            return await _context.Activities.Where(x => x.PetId == id).ToListAsync();
        }
    }
}
