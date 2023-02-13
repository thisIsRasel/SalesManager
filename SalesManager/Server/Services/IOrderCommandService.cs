using SalesManager.Shared.Entities;

namespace SalesManager.Server.Services;
public interface IOrderCommandService
{
    Task CreateAsync(Order order);

    Task UpdateAsync(string id, Order order);

    Task DeleteAsync(string id);
}
