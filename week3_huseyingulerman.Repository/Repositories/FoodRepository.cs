using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Repositories;

namespace week3_huseyingulerman.Repository.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {

        public FoodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddFoodByPetId(Food food)
        {
await _context.Foods.AddAsync(food);
        }
    }
}
