using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Service.Servcices;

namespace week3_huseyingulermanApi.Controllers
{
    [Route("api/v1/healths")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;
        public HealthController(IHealthService healthService)
        {
            _healthService=healthService;
        }
        [HttpGet("{petid}")]
        public async Task<IActionResult> GetById(int petid)
        {
            var appResultHealth = await _healthService.GetHealtyByPetId(petid);
            return Ok(appResultHealth);

        }
        [HttpPatch("{petid}")]
        public async Task<IActionResult> UpdateHealthById(int petid)
        {
            var appResultHealth = await _healthService.GetHealtyByPetId(petid);
            if (appResultHealth!=null)
            {

            }
            return Ok();
        }
    }
}
