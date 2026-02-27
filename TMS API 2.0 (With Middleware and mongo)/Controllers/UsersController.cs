using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TMS_2_with_middleware.Models;
using TMS_2_with_middleware.Repositories;

namespace TMS_2_with_middleware.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IRepository<User> _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest();
            }
            var res = await _repo.GetByIdAsync(id);
            if (res is null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        // params are by default from body
        public async Task<IActionResult> AddUser(User user)
        {
            await _repo.AddAsync(user);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest();
            }
            var success = await _repo.UpdateItemAsync(id, user);
            if (success)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest();
            }
            var success = await _repo.DeleteItemAsync(id);
            if (success)
                return NoContent();
            else
                return NotFound();
        }

    }
}
