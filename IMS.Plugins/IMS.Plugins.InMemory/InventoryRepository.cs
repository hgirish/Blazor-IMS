using IMS.CoreBusiness;
using IMS.USeCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;
public class InventoryRepository : IInventoryRepository
{
    private List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>
        {
            new Inventory{InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2},
            new Inventory{InventoryId = 2, InventoryName = "Bike Body", Quantity=10, Price = 15},
            new Inventory{InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8},
            new Inventory{InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 20, Price = 1 },
        };
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if (ExistsAsync(inventory).Result)
        {
            return Task.CompletedTask;
        }
        var maxId = _inventories.Max(x => x.InventoryId);
        inventory.InventoryId = maxId + 1;
        _inventories.Add(inventory);
        return Task.CompletedTask;
    }

    public Task UpdateInventoryAsync(Inventory inventory)
    {
        var existingInventory = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
        if (existingInventory == null)
        {
            return Task.CompletedTask;
        }
        // if Inventory Name exists with another Id, do not update
        if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
        x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }
        existingInventory.InventoryName = inventory.InventoryName;
        existingInventory.Quantity = inventory.Quantity;
        existingInventory.Price = inventory.Price;

        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(Inventory inventory)
    {
        bool exists = _inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(exists);
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return await Task.FromResult(_inventories);
        }
        return _inventories.Where(x => x.InventoryName.Contains(name,
            StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
    {
        var inv = (_inventories.First(x => x.InventoryId == inventoryId));
        var newInv = new Inventory
        {
            InventoryId = inv.InventoryId,
            InventoryName = inv.InventoryName,
            Price = inv.Price,
            Quantity = inv.Quantity
        };
        return await Task.FromResult(newInv);
    }
}
