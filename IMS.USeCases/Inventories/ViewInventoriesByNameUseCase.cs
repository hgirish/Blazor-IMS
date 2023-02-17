using IMS.CoreBusiness;
using IMS.USeCases.Inventories.Interfaces;
using IMS.USeCases.PluginInterfaces;

namespace IMS.USeCases.Inventories;
public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
    {
        return await _inventoryRepository.GetInventoriesByNameAsync(name);
    }
}
