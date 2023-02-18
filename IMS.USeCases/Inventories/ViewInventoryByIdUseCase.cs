using IMS.CoreBusiness;
using IMS.USeCases.Inventories.Interfaces;
using IMS.USeCases.PluginInterfaces;

namespace IMS.USeCases.Inventories;

public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public async Task<Inventory> ExecuteAsync(int inventoryId)
    {
        return await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
    }
}