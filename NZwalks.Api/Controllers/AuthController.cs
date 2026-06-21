
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.CustomActionFilters;
using NZwalks.Api.Models.DTO;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> usermanager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.usermanager=userManager;
        }
        
        //Register
        [HttpPost]
        [Route("Register")]
        [ActionModel]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var IdentityUser=new IdentityUser{UserName=registerDto.UserName,Email=registerDto.UserName};
            
            var identityResult=await usermanager.CreateAsync(IdentityUser,registerDto.Password);
            if (identityResult.Succeeded)
            {
                if(registerDto.Roles!=null && registerDto.Roles.Any())
                identityResult=await usermanager.AddToRolesAsync(IdentityUser,registerDto.Roles);
                if (identityResult.Succeeded)
                {
                    return Ok("User was Registered Successfully!,Please login");
                }
            }
            return BadRequest("Something went wrong");
        }
    }
}