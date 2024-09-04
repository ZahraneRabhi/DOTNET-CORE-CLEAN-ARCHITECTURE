using App.Domain.Services.ToDo;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAll()
        {
            var items = await _toDoService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetById(int id)
        {
            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> Create(ToDoItem item)
        {
            var createdItem = await _toDoService.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                await _toDoService.UpdateAsync(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _toDoService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            await _toDoService.SeedItemsAsync();
            return NoContent();
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
        }
    }
}
