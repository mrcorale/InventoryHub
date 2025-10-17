namespace InventoryHub.Services;
public class InventoryService
{
    private readonly HttpClient _http;

    public InventoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<InventoryItem>> GetItemsAsync() =>
        await _http.GetFromJsonAsync<List<InventoryItem>>("api/inventory") ?? new();

    public async Task AddItemAsync(InventoryItem item) =>
        await _http.PostAsJsonAsync("api/inventory", item);

    public async Task UpdateItemAsync(InventoryItem item) =>
        await _http.PutAsJsonAsync($"api/inventory/{item.Id}", item);

    public async Task DeleteItemAsync(int id) =>
        await _http.DeleteAsync($"api/inventory/{id}");
}