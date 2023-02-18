using IMS.CoreBusiness;
using IMS.USeCases.Inventories.Interfaces;
using IMS.USeCases.PluginInterfaces;

namespace IMS.USeCases.Inventories;

public class AddInventoryUseCase : IAddInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public AddInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public async Task ExecuteAsync(Inventory inventory)
    {
        if (!await _inventoryRepository.ExistsAsync(inventory))
        {
            await _inventoryRepository.AddInventoryAsync(inventory);
        }
    }
}