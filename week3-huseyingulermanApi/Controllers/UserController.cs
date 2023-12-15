using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Entities;

namespace week3_huseyingulermanApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;


        public UserController(UserManager<AppUser> _userManager)
        {
            this.userManager = _userManager;
          
        }




        //// Kullanıcı İşlemleri

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO user)
        {
            AppUser appuser = new AppUser()
            {
                FİrstName=user.FirstName,
                LastName=user.LastName,
                UserName = user.UserName,
                IsActive=user.IsActive,
                Email = user.Email,
            };
            IdentityResult result = await userManager.CreateAsync(appuser);
                return CreatedAtAction(nameof(GetById), new { id = appuser.Id }, appuser);
           
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var _user = await userManager.FindByIdAsync(userId);  
            return Ok(_user);
        }

        //[HttpGet("kullanicilar/{kullaniciId}")]
        //public ActionResult<Kullanici> GetKullanici(int kullaniciId)
        //{
        //    var kullanici = _context.Kullanicilar.Find(kullaniciId);

        //    if (kullanici == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(kullanici);
        //}


    }
}
