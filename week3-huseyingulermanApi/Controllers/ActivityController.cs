using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Service.Servcices;

namespace week3_huseyingulermanApi.Controllers
{
    [Route("api/v1/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService=activityService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityCreateDTO activity)
        {
            var appResultPet = await _activityService.AddActivityByPetId(activity);
            return StatusCode(201);
        }
        [HttpGet("{petid}")]
        public async Task<IActionResult> GetById(int petid)
        {
            var appResultActivity = await _activityService.GetActivityByPetId(petid);
            return Ok(appResultActivity);

        }
    }
}
