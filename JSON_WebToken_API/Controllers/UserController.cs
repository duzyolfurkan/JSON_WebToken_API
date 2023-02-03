using JSON_WebToken_API.Models;
using JSON_WebToken_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace JSON_WebToken_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Eğer from service kullanılırsa bu şekilde bir injection'a gerek yoktur.
        //private readonly UserManager<User> _userManager;
        //public UserController(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //}
        private readonly IJwtService _jwtService;
        public UserController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("kayit")]
        public async Task<IActionResult> Kayit([FromServices] UserManager<User> userManager, KayitDto kayitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                Email = kayitDto.Email,
                EmailConfirmed = true,
                UserName = kayitDto.Email,
                FirstName = kayitDto.FirstName,
                LastName = kayitDto.LastName,
            };

            var createUserResult = await userManager.CreateAsync(user,kayitDto.Password);

            if (!createUserResult.Succeeded)
            {
                return BadRequest(new AuthResult
                {
                    IsSuccess= false,
                });
            }

            var token = _jwtService.GetJwtToken(user);


            return Ok(new AuthResult
            {
                IsSuccess = true,
                Token = token
            }) ;
        }
    }
}
