using IMS.CoreBusiness;

namespace IMS.USeCases.PluginInterfaces;
public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
}
