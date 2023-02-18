using IMS.CoreBusiness;

namespace IMS.USeCases.Inventories.Interfaces;
public interface IAddInventoryUseCase
{
    Task ExecuteAsync(Inventory inventory);
}