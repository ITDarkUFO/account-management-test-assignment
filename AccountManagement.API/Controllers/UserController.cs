using AccountManagement.Application.DTOs;
using AccountManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRepository repository) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(JsonSerializer.Serialize(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserCreateDto user)
        {
            return Ok();
        }
    }
}
