using IMS.CoreBusiness;

namespace IMS.USeCases.Inventories.Interfaces;
public interface IEditInventoryUseCase
{
    Task ExecuteAsync(Inventory inventory);
}