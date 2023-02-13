using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManager.Server.Data;
using SalesManager.Server.Services;
using SalesManager.Shared.Entities;

namespace SalesManager.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderCommandService _orderCommandService;
    private readonly DataContext _dataContext;

    public OrderController(
        IOrderCommandService orderCommandService,
        DataContext dataContext)
    {
        _orderCommandService = orderCommandService;
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAsync()
    {
        var orders = await _dataContext.Orders
            .Include(o => o.Windows)
            .ThenInclude(w => w.SubElements)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetAsync(string id)
    {
        var order = await _dataContext.Orders
            .Include(o => o.Windows)
            .ThenInclude(w => w.SubElements)
            .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Order order)
    {
        await _orderCommandService.CreateAsync(order);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(string id, Order order)
    {
        await _orderCommandService.UpdateAsync(id, order);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        await _orderCommandService.DeleteAsync(id);
        return Ok();
    }
}
