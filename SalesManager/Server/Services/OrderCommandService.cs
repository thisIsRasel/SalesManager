using Microsoft.EntityFrameworkCore;
using SalesManager.Server.Data;
using SalesManager.Shared.Entities;

namespace SalesManager.Server.Services;
public sealed class OrderCommandService
    : IOrderCommandService
{
    private readonly DataContext _dataContext;

    public OrderCommandService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CreateAsync(Order order)
    {
        order.CreatedAt = DateTime.UtcNow;
        order.UpdatedAt = DateTime.UtcNow;
        _dataContext.Orders.Add(order);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var dbOrder = await _dataContext.Orders
            .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id)) 
            ?? throw new InvalidOperationException($"No order found with id: {id}");

        _dataContext.Orders.Remove(dbOrder);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(string id, Order order)
    {
        var dbOrder = await _dataContext.Orders
            .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id)) 
            ?? throw new InvalidOperationException($"No order found with id: {id}");

        dbOrder.Name = order.Name;
        dbOrder.State = order.State;
        dbOrder.Windows = order.Windows;
        dbOrder.UpdatedAt = DateTime.UtcNow;

        await _dataContext.SaveChangesAsync();
    }
}
