using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewBackend.Application.IService;
using NewBackend.Domain.Entity;
using NewBackend.Infrastructure.Service;

namespace NewBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService,IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails()
        {
            var result = await _userService.GetDetails();
            return Ok(new ResponseModel { StatusCode = 200, StatusMessage = "Success", Data = null });
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateSignup(UserModel userModel)
        {
            var result = await _userService.CreateSignup(userModel);
            return Ok(new ResponseModel { StatusCode = 200, StatusMessage = "User created successfully", Data = null });
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(UserModel userModel)
        {
            var result = await _userService.Update(userModel);
            if (result.StatusCode == 200)
            {
                return Ok(new ResponseModel { StatusCode = 200, StatusMessage = StaticData.successMessage, Data = StaticData.data });
            }
            return BadRequest(new ResponseModel { StatusCode = StaticData.errorCode, StatusMessage = StaticData.errorMessage, Data = StaticData.data });
        }

        [HttpDelete("DeleteUser")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new ResponseModel { StatusCode = StaticData.successcode, StatusMessage =StaticData.successMessage, Data = StaticData.data });
        }

        [HttpPost("ValidateUser")]
        public async Task<IActionResult> Validate([FromBody] LoginDetails loginDetails)
        {
            if (!ModelState.IsValid) return BadRequest(new ResponseModel { StatusCode = StaticData.errorCode, StatusMessage = StaticData.errorMessage, Data = StaticData.data });
            var result = await _userService.Validate(loginDetails);
            if (result == 0)
            {
                return Unauthorized(new ResponseModel { StatusCode = StaticData.errorCode, StatusMessage = StaticData.errorMessage, Data = StaticData.data });
            }


            TokenService t = new TokenService(_config);

            var token = t.GenerateToken(loginDetails);

            return Ok(new ResponseModel { StatusCode = StaticData.successcode, StatusMessage = StaticData.successMessage, Data = token });
        }
    }
}