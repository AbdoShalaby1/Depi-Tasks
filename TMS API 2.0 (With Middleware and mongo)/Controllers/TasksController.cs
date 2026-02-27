using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using TMS_2_with_middleware.Context;
using TMS_2_with_middleware.Models;
using TMS_2_with_middleware.Repositories;

namespace TMS_2_with_middleware.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController(IRepository<TaskItem> _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(string id)
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
        public async Task<IActionResult> AddTask(TaskItem task) 
        {
            await _repo.AddAsync(task);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(string id, TaskItem task)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest();
            }
            var success = await _repo.UpdateItemAsync(id, task);
            if (success)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(string id)
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
