using IMS.CoreBusiness;

namespace IMS.USeCases.PluginInterfaces;
public interface IInventoryRepository
{
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task<bool> ExistsAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    Task<Inventory> GetInventoryByIdAsync(int inventoryId);
}
