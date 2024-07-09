using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewBackend.Application.IService;
using NewBackend.Domain.Entity;

namespace NewBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails()
        {
            return Ok(await _userService.GetDetails());
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateSignup(UserModel userModel)
        {
            return Ok(await _userService.CreateSignup(userModel));
        }
        [HttpPut("UpdateUser")]
        public  async Task<IActionResult> Update(UserModel userModel)
        {
            var result= await _userService.Update(userModel);
            if (result > 0)
            {
               return Ok("User Updated");
            }
            return Ok("User not registered");
            
        }


        [HttpDelete("DeleteUser")]
        public void Delete(int id)
        {
            _userService.Delete(id);

        }
        }

    } 
