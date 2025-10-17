using Microsoft.AspNetCore.Mvc;


namespace InventoryHub.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly InventoryContext _context;

    public InventoryController(InventoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItem>>> GetItems()
        => await _context.Items.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryItem>> GetItem(int id)
    {
        var item = await _context.Items.FindAsync(id);
        return item is null ? NotFound() : item;
    }

    [HttpPost]
    public async Task<ActionResult<InventoryItem>> CreateItem(InventoryItem item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, InventoryItem item)
    {
        if (id != item.Id) return BadRequest();
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item is null) return NotFound();
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}