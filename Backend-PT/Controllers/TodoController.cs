using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PT.Data;
using PT.Models;

namespace PT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    // GET api/todo
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _context.Todos.ToListAsync();
        return Ok(todos);
    }

    // GET api/todo/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    // POST api/todo
    [HttpPost]
    public async Task<IActionResult> Create(TodoItem todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    // PUT api/todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TodoItem updated)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
            return NotFound();

        todo.Title = updated.Title;
        todo.Completed = updated.Completed;

        await _context.SaveChangesAsync();

        return Ok(todo);
    }

    // DELETE api/todo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
            return NotFound();

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
