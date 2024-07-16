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
            var result = await _userService.GetDetails();
            return Ok(new ResponseModel { StatusCode = 200, StatusMessage = "Success", Data = null });
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateSignup(UserModel userModel)
        {
            var result = await _userService.CreateSignup(userModel);
            return Ok(new ResponseModel { StatusCode = 201, StatusMessage = "User created successfully", Data = null });
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(UserModel userModel)
        {
            var result = await _userService.Update(userModel);
            if (result > 0)
            {
                return Ok(new ResponseModel { StatusCode = 200, StatusMessage = "User updated successfully", Data = null });
            }
            return Ok(new ResponseModel { StatusCode = 404, StatusMessage = "User not found", Data = null });
        }

        [HttpDelete("DeleteUser")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new ResponseModel { StatusCode = 200, StatusMessage = "User deleted successfully", Data = null });
        }

        [HttpPost("ValidateUser")]
        public async Task<IActionResult> Validate([FromBody] LoginDetails loginDetails)
        {
            if (!ModelState.IsValid) return BadRequest(new ResponseModel { StatusCode = 400, StatusMessage = "Invalid request", Data = null });
            var result = await _userService.Validate(loginDetails);
            if (result == 0)
            {
                return Unauthorized(new ResponseModel { StatusCode = 401, StatusMessage = "Invalid credentials", Data = null });
            }
            var token = _userService.GenerateToken(loginDetails);

            return Ok(new ResponseModel { StatusCode = 200, StatusMessage = "User validated successfully", Data = token });
        }
    }
}