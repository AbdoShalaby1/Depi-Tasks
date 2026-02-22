using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Context;
using TMS.Models;

namespace TMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController(DBContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }

        [HttpPost]
        // params are by default from body
        public async Task<IActionResult> AddTask(TaskItem task) 
        {
            _context.Tasks.Add(task); // no AddAsync because does not touch the db yet
            await _context.SaveChangesAsync(); // this is the only db hit
            return Created();
        }
    }
}
