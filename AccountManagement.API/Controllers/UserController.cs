using AccountManagement.Application.DTOs;
using AccountManagement.API.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AccountManagement.Application.Interfaces;

namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(JsonSerializer.Serialize(user));
        }

        [HttpPost]
        [ServiceFilter<XDeviceFilter>]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCreateDto user)
        {
            var xDevice = (string)HttpContext.Items["X-Device"]!;

            var (isValid, errors) = await _userService.ValidateAndCreateUserAsync(xDevice, user);

            if (!isValid)
            {
                foreach (var error in errors)
                    foreach (var errorMember in error.MemberNames)
                        ModelState.TryAddModelError(errorMember, error.ErrorMessage ?? "An unknown error occurred");

                return BadRequest(ModelState);
            }

            return Ok("The user was created successfully");
        }

        [HttpPost("find")]
        public async Task<IActionResult> FindUserAsync([FromBody] FindUserDto userData)
        {
            var user = await _userService.FindUserAsync(userData);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
