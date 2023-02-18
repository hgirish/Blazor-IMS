using IMS.CoreBusiness;
using IMS.USeCases.Inventories.Interfaces;
using IMS.USeCases.PluginInterfaces;

namespace IMS.USeCases.Inventories;

public class EditInventoryUseCase : IEditInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public EditInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public async Task ExecuteAsync(Inventory inventory)
    {
        await _inventoryRepository.UpdateInventoryAsync(inventory);
    }
}
