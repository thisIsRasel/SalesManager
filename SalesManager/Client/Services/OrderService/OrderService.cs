using SalesManager.Shared.Entities;
using System.Net.Http.Json;

namespace SalesManager.Client.Services.OrderService;

public sealed class OrderService : IOrderService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Order?> GetOrderAsync(string id)
    {
        var client = _httpClientFactory.CreateClient("api");

        var order = await client
            .GetFromJsonAsync<Order>($"api/order/{id}");

        return order;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        var client = _httpClientFactory.CreateClient("api");

        var orders = await client
            .GetFromJsonAsync<List<Order>>("api/order");

        if (orders is null)
        {
            return new List<Order>();
        }

        return orders;
    }

    public async Task<bool> CreateOrderAsync(Order order)
    {
        var client = _httpClientFactory.CreateClient("api");

        var result = await client
            .PostAsJsonAsync("api/order", order);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateOrderAsync(string id, Order order)
    {
        var client = _httpClientFactory.CreateClient("api");

        var result = await client
            .PutAsJsonAsync($"api/order/{id}", order);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var client = _httpClientFactory.CreateClient("api");

        var result = await client
            .DeleteAsync($"api/order/{id}");

        return result.IsSuccessStatusCode;
    }
}
