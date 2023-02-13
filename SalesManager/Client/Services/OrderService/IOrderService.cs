using SalesManager.Shared.Entities;

namespace SalesManager.Client.Services.OrderService;

public interface IOrderService
{
    Task<Order?> GetOrderAsync(string id);

    Task<List<Order>> GetOrdersAsync();

    Task<bool> CreateOrderAsync(Order order);

    Task<bool> UpdateOrderAsync(string id, Order order);

    Task<bool> DeleteAsync(string id);
}
