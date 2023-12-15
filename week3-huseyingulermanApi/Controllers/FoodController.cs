using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Service.Servcices;

namespace week3_huseyingulermanApi.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService=foodService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appResultFoods = await _foodService.GetAllActiveAsync();
            return Ok(appResultFoods);

        }
        [HttpPost]
        public async Task<IActionResult> Create(FoodCreateDTO foodCreateDTO)
        {
            var appResultFood = await _foodService.AddFoodByPetId(foodCreateDTO);
            return StatusCode(201);
        }
    }
}
