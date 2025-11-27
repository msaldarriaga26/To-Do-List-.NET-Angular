using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PT.Data;
using PT.DTOs;
using PT.Models;

namespace PT.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Todos.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TodoDTO dto)
    {
        var todo = new TodoItem
        {
            Title = dto.Title,
            Completed = dto.Completed
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return Ok(todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TodoDTO dto)
    {
        var task = await _context.Todos.FindAsync(id);
        if (task == null) return NotFound();

        task.Title = dto.Title;
        task.Completed = dto.Completed;

        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.Todos.FindAsync(id);
        if (task == null) return NotFound();

        _context.Todos.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id}/toggle")]
    public async Task<IActionResult> Toggle(int id)
    {
        var task = await _context.Todos.FindAsync(id);
        if (task == null) return NotFound();

        task.Completed = !task.Completed;

        await _context.SaveChangesAsync();
        return Ok(task);
    }

    [HttpGet("metrics")]
    public IActionResult GetMetrics()
    {
        var total = _context.Todos.Count();
        var completed = _context.Todos.Count(t => t.Completed);
        var pending = total - completed;

        return Ok(new { total, completed, pending });
    }
}
