using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.DTOs.Update;
using week3_huseyingulerman.Core.Enums;
using week3_huseyingulerman.Core.Services;

namespace week3_huseyingulermanApi.Controllers
{
    [Route("api/v1/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petservice;
        public PetController(IPetService petService)
        {
            _petservice=petService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appResultPets = await _petservice.GetAllActiveAsync();
            return Ok(appResultPets.Data);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appResultPet = await _petservice.GetByIdAsync(id);
            return Ok(appResultPet.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PetCreateDTO pet)
        {
            var appResultPet = await _petservice.AddAsync(pet);
            return CreatedAtAction(nameof(GetById), new { id = appResultPet.Data.Id }, appResultPet);
        }
        [HttpPut]
        public async Task<IActionResult> Update(PetUpdateDTO pet)
        {
            var appResultPet = await _petservice.UpdateAsync(pet);

            return Ok(appResultPet.StatusCode);
        }
    }
}
